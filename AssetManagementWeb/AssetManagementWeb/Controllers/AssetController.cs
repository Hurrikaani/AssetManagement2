﻿using AssetManagementWeb.Models;
using AssetManagementWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AssetManagementWeb.Database;

namespace AssetManagementWeb.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asset/Create
        [HttpPost]
        public JsonResult AssignLocation()
        {
            string json = Request.InputStream.ReadToEnd();
            AssignLocationModel inputData =
                JsonConvert.DeserializeObject<AssignLocationModel>(json);

            bool success = false;
            string error = "";
            DataEntities entities = new DataEntities();
            try
            {

                int locationId = (from l in entities.AssetsLocations
                                  where l.Code == inputData.LocationCode
                                  select l.Id).FirstOrDefault();

                int assetId = (from a in entities.Assets
                                  where a.Code == inputData.AssetCode
                                  select a.Id).FirstOrDefault();

                if((locationId > 0) && (assetId > 0))
                {
                    AssetsLocations newEntry = new AssetsLocations();
                    newEntry.LocationId = locationId;
                    newEntry.AssetId = assetId;
                    newEntry.LastSeen = DateTime.Now;

                    entities.AssetsLocations.Add(newEntry);
                    entities.SaveChanges();

                    success = true;
                            
                }

            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            var result = new { success = success, error = error };
            return Json(result);

        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asset/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asset/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
