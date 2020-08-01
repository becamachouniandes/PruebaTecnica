using PruebaTecnica.Entities;
using PruebaTecnica.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PruebaTecnica.Controllers
{
    public class UserController : Controller
    {
        private readonly ServiceUserClient _serviceUserClient;

        public UserController()
        {
            _serviceUserClient = new ServiceUserClient();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _serviceUserClient.GetUsers();

            List<UserModel> userModels = users.Select(u => new UserModel
            {
                DateTime = u.BirthDate,
                Gender = u.Gender,
                Id = u.Id,
                Name = u.Name,
                GenderName = NameGender(u.Gender)
            }).ToList();

            return View(userModels);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null && id > 0)
            {
                User user = _serviceUserClient.GetUser(id.Value);

                UserModel userModel = new UserModel
                {
                    DateTime = user.BirthDate,
                    Gender = user.Gender,
                    Id = user.Id,
                    Name = user.Name,
                    GenderName = NameGender(user.Gender)
                };

                return View(userModel);
            }

            return RedirectToAction("Index");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel collection)
        {
            try
            {
                User user = new User
                {
                    BirthDate = collection.DateTime,
                    Gender = collection.Gender,
                    Name = collection.Name
                };


                _serviceUserClient.CreateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id!=null && id > 0)
            {
                User user = _serviceUserClient.GetUser(id.Value);

                UserModel userModel = new UserModel
                {
                    DateTime = user.BirthDate,
                    Gender = user.Gender,
                    Id = user.Id,
                    Name = user.Name
                };

                return View(userModel);
            }

            return RedirectToAction("Index");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel collection)
        {
            try
            {
                User user = new User
                {
                    BirthDate = collection.DateTime,
                    Gender = collection.Gender,
                    Name = collection.Name,
                    Id = collection.Id
                };

                _serviceUserClient.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                User user = _serviceUserClient.GetUser(id.Value);

                UserModel userModel = new UserModel
                {
                    DateTime = user.BirthDate,
                    Gender = user.Gender,
                    Id = user.Id,
                    Name = user.Name,
                    GenderName = NameGender(user.Gender)
                };

                return View(userModel);
            }

            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserModel collection)
        {
            try
            {
                _serviceUserClient.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private string NameGender(string gender)
        {
            switch(gender)
            {
                case "f":
                     return "Femenino";
                case "m":
                    return "Masculino";
                default:
                    return string.Empty;
            }
        }
    }
}
