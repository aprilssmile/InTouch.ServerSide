using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InTouch.FirebaseCloudMessaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InTouch.Controllers
{

    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private FirebaseProxy _firebaseProxy;
        
        public NotificationsController(FirebaseProxy firebaseProxy)
        {
            _firebaseProxy = firebaseProxy;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
           return await _firebaseProxy.SendTestNotification();
        }
    }
}
