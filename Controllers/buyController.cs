using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBH.Models;

namespace WedBH.Controllers
{
    public class buyController : Controller
    {
        static String maHoaDon = "BH6";
        static double tongGiaTienHoaDon = 500000;
        Model1 db = new Model1();
        // GET: buy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PaymentByMomo(FormCollection collection)
        {
            //KhachHang kh = Session["KhachHang"] as KhachHang;
            var hoaDon = db.Baohiems.FirstOrDefault(p => p.MABH == maHoaDon);


            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMOIP1R20220408";
            string accessKey = "2Rq8mwC0AtwgOHBR";
            string serectkey = "UavKQ3fniXWMUwElozhdr67CrfTas1TC";
            string orderInfo = DateTime.Now.ToString();
            string returnUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";// nhận đường dẫn từ momo
            string ipnUrl = "https://localhost:44331/Card/PaymentMomo";
            string redirectUrl = "https://localhost:44331/Card/ReturnUrl";
            string requestType = "captureWallet";

            string amount = tongGiaTienHoaDon.ToString();
            string orderId = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            ////Before sign HMAC SHA256 signature
            string rawHash = "accessKey=" + accessKey +
                 "&amount=" + amount +
                 "&extraData=" + extraData +
                 "&ipnUrl=" + ipnUrl +
                 "&orderId=" + orderId +
                 "&orderInfo=" + orderInfo +
                 "&partnerCode=" + partnerCode +
                 "&redirectUrl=" + redirectUrl +
                 "&requestId=" + requestId +
                 "&requestType=" + requestType
                 ;

            MoMoSecurity crypto = new MoMoSecurity();
            ////sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            ////build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }

            };
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }
    }
}