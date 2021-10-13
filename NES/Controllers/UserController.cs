using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NES.Models;

namespace NES.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Save User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserViewModel model)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<Role> listRole = db.Role.ToList();
                    ViewBag.RoleList = new SelectList(listRole, "RoleID", "RoleName");

                    List<OrgUnit> listOrgUnit = db.OrgUnit.ToList();
                    ViewBag.OrgUnitList = new SelectList(listOrgUnit, "OrgUnitID", "OrgUnitName");

                    List<UserDepartmentView> listUserDepartmentView = db.UserDepartmentView.ToList();
                    ViewBag.UserDepartmentViewList = new SelectList(listUserDepartmentView, "DepartmentID", "DepartmentName");

                    List<UserPositionView> listUserPositionView = db.UserPositionView.ToList();
                    ViewBag.UserPositionViewList = new SelectList(listUserPositionView, "PositionID", "PositionName");

                    if (model.UserID > 0)
                    {
                        // Update user
                        User userEdit = db.User.SingleOrDefault(x => x.UserID == model.UserID);
                        userEdit.UserName = model.UserName;
                        userEdit.Password = model.Password;
                        userEdit.FirstName = model.FirstName;
                        userEdit.LastName = model.LastName;
                        userEdit.Note = model.Note;
                        userEdit.RoleID = model.RoleID;
                        userEdit.DateCreated = model.DateCreated;
                        userEdit.IsActivated = model.IsActivated;
                        userEdit.Gender = model.Gender;
                        userEdit.OrgUnitID = model.OrgUnitID;
                        userEdit.DepartmentID = model.DepartmentID;
                        userEdit.PositionID = model.PositionID;

                        db.SaveChanges();
                        return View(model);
                    }
                    else
                    {
                        var userExists = db.User.Where(x => x.UserName == model.UserName).FirstOrDefault();

                        if (userExists == null)
                        {
                            // Insert new user
                            User userNew = new User
                            {
                                UserName = model.UserName,
                                Password = model.Password,
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                Note = model.Note,
                                RoleID = model.RoleID,
                                DateCreated = model.DateCreated,
                                IsActivated = model.IsActivated,
                                Gender = model.Gender,
                                OrgUnitID = model.OrgUnitID,
                                DepartmentID = model.DepartmentID,
                                PositionID = model.PositionID
                            };

                            db.User.Add(userNew);
                            db.SaveChanges();
                            return View(model);
                        }
                        else
                        {
                            //return ExecutionError("<b>Username not avialable!. Choose different user name.</b>");
                            //Response.StatusCode = (int)HttpStatusCode.Conflict;
                            //return Json(HttpStatusCode.Conflict);

                            return new HttpStatusCodeResult(HttpStatusCode.Conflict);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                //return Json(HttpStatusCode.RequestTimeout);

                return new HttpStatusCodeResult(HttpStatusCode.RequestTimeout);
            }
        }

        // Delete User
        [HttpGet]
        public ActionResult DeleteUser(int UserId)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    User usr = db.User.Where(x => x.UserID == UserId).FirstOrDefault();
                    db.User.Remove(usr);
                    db.SaveChanges();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // User details
        [HttpGet]
        public ActionResult UserDetails(int UserID)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<UserViewModel> listUser = db.User.Where(x => x.UserID == UserID).Select(x => new UserViewModel
                    {
                        UserID = x.UserID,
                        UserName = x.UserName,
                        Password = x.Password,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Note = x.Note,
                        RoleName = x.Role.RoleName,
                        DateCreated = x.DateCreated,
                        IsActivated = x.IsActivated,
                        Gender = x.Gender,
                        OrgUnitName = x.OrgUnit.OrgUnitName,
                        DepartmentName = x.Department.DepartmentName,
                        PositionName = x.Position.PositionName
                    }).ToList();

                    ViewBag.UserList = listUser;

                    return PartialView("_UserDetails");
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // Add or Edit User
        [HttpGet]
        public ActionResult AddEditUser(int UserId = 0)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    UserViewModel model = new UserViewModel();

                    List<Role> listRole = db.Role.ToList();
                    ViewBag.RoleList = new SelectList(listRole, "RoleID", "RoleName");

                    List<OrgUnit> listOrgUnit = db.OrgUnit.ToList();
                    ViewBag.OrgUnitList = new SelectList(listOrgUnit, "OrgUnitID", "OrgUnitName");
                    // Display existing User for editing
                    if (UserId > 0)
                    {
                        User user = db.User.SingleOrDefault(x => x.UserID == UserId);

                        model.UserID = user.UserID;
                        model.UserName = user.UserName;
                        model.Password = user.Password;
                        model.FirstName = user.FirstName;
                        model.LastName = user.LastName;
                        model.Note = user.Note;
                        model.RoleID = user.RoleID;
                        model.DateCreated = user.DateCreated;
                        model.IsActivated = user.IsActivated;
                        model.Gender = user.Gender;
                        model.OrgUnitID = user.OrgUnitID;
                        model.DepartmentID = user.DepartmentID;
                        model.PositionID = user.PositionID;

                        List<UserDepartmentView> listUserDepartmentView = db.UserDepartmentView.Where(x => x.OrgUnitID == user.OrgUnitID).ToList();
                        ViewBag.UserDepartmentViewList = new SelectList(listUserDepartmentView, "DepartmentID", "DepartmentName");

                        List<UserPositionView> listUserPositionView = db.UserPositionView.Where(x => x.DepartmentID == user.DepartmentID).ToList();
                        ViewBag.UserPositionViewList = new SelectList(listUserPositionView, "PositionID", "PositionName");

                        TempData["userGender"] = user.Gender;
                        TempData.Keep();
                    }
                    // New user
                    else
                    {
                        List<UserDepartmentView> listUserDepartmentView = db.UserDepartmentView.ToList();
                        ViewBag.UserDepartmentViewList = new SelectList(listUserDepartmentView, "DepartmentID", "DepartmentName");

                        List<UserPositionView> listUserPositionView = db.UserPositionView.ToList();
                        ViewBag.UserPositionViewList = new SelectList(listUserPositionView, "PositionID", "PositionName");
                    }

                    return PartialView("_UserAddEdit", model);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // Get all Users Data to JQ Datatables
        [HttpGet]
        public ActionResult GetUsersData()
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<Role> listRole = db.Role.ToList();
                    ViewBag.RoleList = new SelectList(listRole, "RoleID", "RoleName");

                    List<OrgUnit> listOrgUnit = db.OrgUnit.ToList();
                    ViewBag.OrgUnitList = new SelectList(listOrgUnit, "OrgUnitID", "OrgUnitName");

                    List<UserDepartmentView> listUserDepartmentView = db.UserDepartmentView.ToList();
                    ViewBag.UserDepartmentViewList = new SelectList(listUserDepartmentView, "DepartmentID", "DepartmentName");

                    List<UserPositionView> listUserPositionView = db.UserPositionView.ToList();
                    ViewBag.UserPositionViewList = new SelectList(listUserPositionView, "PositionID", "PositionName");

                    List<UserViewModel> usersList = db.User.Select(x => new UserViewModel
                    {
                        UserID = x.UserID,
                        UserName = x.UserName,
                        Password = x.Password,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Note = x.Note,
                        RoleName = x.Role.RoleName,
                        DateCreated = x.DateCreated,
                        IsActivated = x.IsActivated,
                        Gender = x.Gender,
                        OrgUnitName = x.OrgUnit.OrgUnitName,
                        DepartmentName = x.Department.DepartmentName,
                        PositionName = x.Position.PositionName
                    }).OrderBy(o => o.UserName).ToList();

                    return Json(new { data = usersList }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // Fill Department dropdown
        [HttpGet]
        public ActionResult FillDepartments(int OrgUnitID)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<UserDepartmentView> listDepartments = db.UserDepartmentView.Where(x => x.OrgUnitID == OrgUnitID).ToList();
                    return Json(listDepartments, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(408);
            }
        }

        // Fill Positions dropdown
        [HttpGet]
        public ActionResult FillPositions(int DepartmentID)
        {
            try
            {
                using (UserEntities db = new UserEntities())
                {
                    List<UserPositionView> listPositions = db.UserPositionView.Where(x => x.DepartmentID == DepartmentID).ToList();
                    return Json(listPositions, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(408);
            }
        }
    }
}