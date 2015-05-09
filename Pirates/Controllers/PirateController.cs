using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Numerics;

namespace Pirates.Controllers
{
    public class PirateController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Coins(int pirates)
        {
            if (pirates < 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception());
            }
            else if (pirates == 2)
            {
                return Request.CreateResponse(HttpStatusCode.OK, 15);
            }
            else if (pirates > 142)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "a lot of freaking coins.");
            }
            else
            {
                BigInteger coins = new BigInteger(Math.Pow(pirates - 1, pirates));

                int i = 0;

                while (i < pirates)
                {
                    coins = ((coins * pirates) + 1) / (pirates - 1);
                    i++;
                }

                return Request.CreateResponse(HttpStatusCode.OK, (coins * pirates) + 1 - pirates);
            }
        }
    }
}
