﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Stud_io.Payment.Services.Interfaces;

namespace Stud_io.Payment.Services.Implementations
{
    public class MailKitEmailService : IMailKitEmailService
    {

        public void SendEmail(string to, string subject, string html, string from)
        {
            // create message
            var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            var sender = new MailboxAddress(string.Empty, "studio.qendrastudentore@gmail.com");
            email.From.Add(sender);
            email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = html };
            email.Body = new TextPart(TextFormat.Html) { Text = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html\r\n  xmlns=\"http://www.w3.org/1999/xhtml\"\r\n  xmlns:v=\"urn:schemas-microsoft-com:vml\"\r\n  xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n>\r\n  <head>\r\n    <!--[if gte mso 9]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG />\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    <![endif]-->\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <meta name=\"x-apple-disable-message-reformatting\" />\r\n    <!--[if !mso]><!-->\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <!--<![endif]-->\r\n    <title></title>\r\n\r\n    <style type=\"text/css\">\r\n      @media only screen and (min-width: 520px) {\r\n        .u-row {\r\n          width: 500px !important;\r\n        }\r\n        .u-row .u-col {\r\n          vertical-align: top;\r\n        }\r\n\r\n        .u-row .u-col-100 {\r\n          width: 500px !important;\r\n        }\r\n      }\r\n\r\n      @media (max-width: 520px) {\r\n        .u-row-container {\r\n          max-width: 100% !important;\r\n          padding-left: 0px !important;\r\n          padding-right: 0px !important;\r\n        }\r\n        .u-row .u-col {\r\n          min-width: 320px !important;\r\n          max-width: 100% !important;\r\n          display: block !important;\r\n        }\r\n        .u-row {\r\n          width: 100% !important;\r\n        }\r\n        .u-col {\r\n          width: 100% !important;\r\n        }\r\n        .u-col > div {\r\n          margin: 0 auto;\r\n        }\r\n      }\r\n      body {\r\n        margin: 0;\r\n        padding: 0;\r\n      }\r\n\r\n      table,\r\n      tr,\r\n      td {\r\n        vertical-align: top;\r\n        border-collapse: collapse;\r\n      }\r\n\r\n      p {\r\n        margin: 0;\r\n      }\r\n\r\n      .ie-container table,\r\n      .mso-container table {\r\n        table-layout: fixed;\r\n      }\r\n\r\n      * {\r\n        line-height: inherit;\r\n      }\r\n\r\n      a[x-apple-data-detectors=\"true\"] {\r\n        color: inherit !important;\r\n        text-decoration: none !important;\r\n      }\r\n\r\n      table,\r\n      td {\r\n        color: #000000;\r\n      }\r\n    </style>\r\n  </head>\r\n\r\n  <body\r\n    class=\"clean-body u_body\"\r\n    style=\"\r\n      margin: 0;\r\n      padding: 0;\r\n      -webkit-text-size-adjust: 100%;\r\n      background-color: #e7e7e7;\r\n      color: #000000;\r\n    \"\r\n  >\r\n    <!--[if IE]><div class=\"ie-container\"><![endif]-->\r\n    <!--[if mso]><div class=\"mso-container\"><![endif]-->\r\n    <table\r\n      style=\"\r\n        border-collapse: collapse;\r\n        table-layout: fixed;\r\n        border-spacing: 0;\r\n        mso-table-lspace: 0pt;\r\n        mso-table-rspace: 0pt;\r\n        vertical-align: top;\r\n        min-width: 320px;\r\n        margin: 0 auto;\r\n        background-color: #e7e7e7;\r\n        width: 100%;\r\n      \"\r\n      cellpadding=\"0\"\r\n      cellspacing=\"0\"\r\n    >\r\n      <tbody>\r\n        <tr style=\"vertical-align: top\">\r\n          <td\r\n            style=\"\r\n              word-break: break-word;\r\n              border-collapse: collapse !important;\r\n              vertical-align: top;\r\n            \"\r\n          >\r\n            <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #e7e7e7;\"><![endif]-->\r\n\r\n            <div\r\n              class=\"u-row-container\"\r\n              style=\"padding: 0px; background-color: transparent\"\r\n            >\r\n              <div\r\n                class=\"u-row\"\r\n                style=\"\r\n                  margin: 0 auto;\r\n                  min-width: 320px;\r\n                  max-width: 500px;\r\n                  overflow-wrap: break-word;\r\n                  word-wrap: break-word;\r\n                  word-break: break-word;\r\n                  background-color: transparent;\r\n                \"\r\n              >\r\n                <div\r\n                  style=\"\r\n                    border-collapse: collapse;\r\n                    display: table;\r\n                    width: 100%;\r\n                    height: 100%;\r\n                    background-color: transparent;\r\n                  \"\r\n                >\r\n                  <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:500px;\"><tr style=\"background-color: transparent;\"><![endif]-->\r\n\r\n                  <!--[if (mso)|(IE)]><td align=\"center\" width=\"500\" style=\"width: 500px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\r\n                  <div\r\n                    class=\"u-col u-col-100\"\r\n                    style=\"\r\n                      max-width: 320px;\r\n                      min-width: 500px;\r\n                      display: table-cell;\r\n                      vertical-align: top;\r\n                    \"\r\n                  >\r\n                    <div style=\"height: 100%; width: 100% !important\">\r\n                      <!--[if (!mso)&(!IE)]><!--><div\r\n                        style=\"\r\n                          box-sizing: border-box;\r\n                          height: 100%;\r\n                          padding: 0px;\r\n                          border-top: 0px solid transparent;\r\n                          border-left: 0px solid transparent;\r\n                          border-right: 0px solid transparent;\r\n                          border-bottom: 0px solid transparent;\r\n                        \"\r\n                      ><!--<![endif]-->\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <table\r\n                                  width=\"100%\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  border=\"0\"\r\n                                >\r\n                                  <tr>\r\n                                    <td\r\n                                      style=\"\r\n                                        padding-right: 0px;\r\n                                        padding-left: 0px;\r\n                                        width: 50px;\r\n                                        height: 50px;\r\n                                      \"\r\n                                      align=\"center\"\r\n                                    >\r\n                                      <?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n                                      <!-- Generator: Adobe Illustrator 25.0.0, SVG Export Plug-In . SVG Version: 6.00 Build 0)  -->\r\n                                      <svg\r\n                                        version=\"1.1\"\r\n                                        id=\"Layer_1\"\r\n                                        xmlns=\"http://www.w3.org/2000/svg\"\r\n                                        xmlns:xlink=\"http://www.w3.org/1999/xlink\"\r\n                                        x=\"0px\"\r\n                                        y=\"0px\"\r\n                                        viewBox=\"0 0 2000 2000\"\r\n                                        style=\"\r\n                                          width: 80px;\r\n                                          height: 80px;\r\n                                          enable-background: new 0 0 2000 2000;\r\n                                        \"\r\n                                        xml:space=\"preserve\"\r\n                                      >\r\n                                        <style type=\"text/css\">\r\n                                          .st0 {\r\n                                            fill: url(#SVGID_1_);\r\n                                          }\r\n                                          .st1 {\r\n                                            fill: #bf1a2f;\r\n                                          }\r\n                                        </style>\r\n                                        <g id=\"Bg\"></g>\r\n                                        <g\r\n                                          id=\"Layer_2_00000049209495223073506960000016952762608379566494_\"\r\n                                        ></g>\r\n                                        <g id=\"Layer_1_1_\">\r\n                                          <linearGradient\r\n                                            id=\"SVGID_1_\"\r\n                                            gradientUnits=\"userSpaceOnUse\"\r\n                                            x1=\"254.0119\"\r\n                                            y1=\"505.1461\"\r\n                                            x2=\"1624.7598\"\r\n                                            y2=\"505.1461\"\r\n                                            gradientTransform=\"matrix(1 0 0 -1 0 2000)\"\r\n                                          >\r\n                                            <stop\r\n                                              offset=\"0\"\r\n                                              style=\"stop-color: #5e1a2f\"\r\n                                            />\r\n                                            <stop\r\n                                              offset=\"0.17\"\r\n                                              style=\"stop-color: #741a2f\"\r\n                                            />\r\n                                            <stop\r\n                                              offset=\"0.54\"\r\n                                              style=\"stop-color: #9c1a2f\"\r\n                                            />\r\n                                            <stop\r\n                                              offset=\"0.83\"\r\n                                              style=\"stop-color: #b61a2f\"\r\n                                            />\r\n                                            <stop\r\n                                              offset=\"1\"\r\n                                              style=\"stop-color: #bf1a2f\"\r\n                                            />\r\n                                          </linearGradient>\r\n                                          <path\r\n                                            class=\"st0\"\r\n                                            d=\"M385.6,1021.9l359.9,359.9c34,34,86,42.4,129,20.9l638.6-319.5c51.3-25.7,111.6,11.6,111.6,69v403.7\r\n\t\tc0,29.2-16.5,55.8-42.5,68.9l-705.1,353.8c-42.9,21.6-94.8,13.3-128.9-20.6l-471.4-469c-14.5-14.5-22.7-34.1-22.7-54.7v-358\r\n\t\tC254,1007.7,337.1,973.3,385.6,1021.9z\"\r\n                                          />\r\n                                          <path\r\n                                            class=\"st1\"\r\n                                            d=\"M692.1,1125.5l616.6-307.2c33.1-16.5,46.6-56.7,30.1-89.8c-3.1-6.3-7.2-12-12.1-17l-5.5-6.3\r\n\t\tc-20.4-20.8-51.8-26-77.8-12.9L548,1041.4c-25.8,12.9-56.9,7.9-77.3-12.5L88.5,647.2c-26.2-26.1-26.2-68.5,0-94.7\r\n\t\tc5.1-5.1,11-9.3,17.4-12.5l1046-523.4c25.8-12.9,56.9-7.8,77.3,12.6l96.4,96.5c26.1,26.2,26.1,68.5,0,94.7\r\n\t\tc-5.1,5.1-11,9.3-17.5,12.6L692.3,539.7c-33.1,16.5-46.6,56.7-30.1,89.8c3.2,6.5,7.5,12.4,12.6,17.5l0,0\r\n\t\tc20.5,20.4,51.7,25.4,77.6,12.4l691.7-350c25.8-13.1,57.1-8.1,77.6,12.4l389.8,389.6c26.2,26.1,26.2,68.5,0,94.7\r\n\t\tc-5.1,5.1-11,9.3-17.4,12.6L848.3,1341.7c-25.8,12.9-57,7.9-77.3-12.6l-96.4-96.3c-26.1-26.1-26.1-68.5,0-94.7\r\n\t\tC679.7,1133,685.6,1128.8,692.1,1125.5z\"\r\n                                          />\r\n                                          <path\r\n                                            class=\"st1\"\r\n                                            d=\"M1864.9,905L1864.9,905c-28.2,14.3-46.1,43.3-46,74.9v383.5c0,6.5,5.2,11.7,11.7,11.7c1.7,0,3.4-0.4,5-1.1\r\n\t\tl15.4-7.3c22.4-10.7,36.6-33.2,36.6-58l-0.2-389.8c0-8.5-6.9-15.5-15.5-15.5C1869.5,903.3,1867.1,903.9,1864.9,905z\"\r\n                                          />\r\n                                          <path\r\n                                            class=\"st1\"\r\n                                            d=\"M1897.5,1394.9c15.6,15.6,3.1,45.8-12.9,71.7c-17.1,27.7-57.7,28.1-75.7,0.9c-10.4-15.6-15.9-31.7-5.3-42.3\r\n\t\tc6.9-6.9,13.6-8,19.7-6.2c16.3,4.9,34.2,0,42.6-14.8C1873.8,1390.5,1884.4,1381.9,1897.5,1394.9z\"\r\n                                          />\r\n                                        </g>\r\n                                      </svg>\r\n                                    </td>\r\n                                  </tr>\r\n                                </table>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <h1\r\n                                  style=\"\r\n                                    margin: 0px;\r\n                                    line-height: 140%;\r\n                                    text-align: center;\r\n                                    word-wrap: break-word;\r\n                                    font-size: 22px;\r\n                                    font-weight: 400;\r\n                                  \"\r\n                                >\r\n                                  <strong>Pagesa u krye me sukses!</strong>\r\n                                </h1>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <table\r\n                          style=\"font-family: arial, helvetica, sans-serif\"\r\n                          role=\"presentation\"\r\n                          cellpadding=\"0\"\r\n                          cellspacing=\"0\"\r\n                          width=\"100%\"\r\n                          border=\"0\"\r\n                        >\r\n                          <tbody>\r\n                            <tr>\r\n                              <td\r\n                                style=\"\r\n                                  overflow-wrap: break-word;\r\n                                  word-break: break-word;\r\n                                  padding: 10px;\r\n                                  font-family: arial, helvetica, sans-serif;\r\n                                \"\r\n                                align=\"left\"\r\n                              >\r\n                                <div\r\n                                  style=\"\r\n                                    font-size: 14px;\r\n                                    line-height: 140%;\r\n                                    text-align: left;\r\n                                    word-wrap: break-word;\r\n                                  \"\r\n                                >\r\n                                  <p style=\"line-height: 140%\">\r\n                                    Përshëndetje i/e nderuar!<br /><br />\r\n                                  </p>\r\n                                  <p style=\"line-height: 140%\">\r\n                                    Jemi të kënaqur t'ju njoftojmë se pagesa\r\n                                    juaj është kryer me sukses. Ky email ju\r\n                                    informon se pagesa juaj është pranuar dhe\r\n                                    akceptuar. Vlerësojmë veprimin tuaj të\r\n                                    shpejtë në plotësimin e detyrimit për\r\n                                    pagesë.\r\n                                    <br /><br />\r\n                                  </p>\r\n                                  <p style=\"line-height: 140%\">\r\n                                    Ju falenderojmë për besimin dhe përzgjedhjen\r\n                                    tuaj për shërbimet tona. Ne jemi të gatshëm\r\n                                    t'ju ndihmojmë në çdo pyetje ose shqetësim\r\n                                    që keni në lidhje me këtë pagesë ose çështje\r\n                                    të tjera. Ju lutemi të mos hezitoni të\r\n                                    kontaktoni ekipin tonë të mbështetjes së\r\n                                    klientëve në [Informacioni për kontakt].\r\n                                    Jemi këtu për t'ju asistuar.\r\n\r\n                                    <br /><br />\r\n                                  </p>\r\n                                  <p style=\"line-height: 140%\">\r\n                                    Ju falenderojmë për mbështetjen tuaj të\r\n                                    vazhdueshme dhe zgjedhjen e shërbimeve tona.\r\n                                    Shpresojmë të shërbejmë sërish në të\r\n                                    ardhmen.\r\n                                    <br /><br />\r\n                                  </p>\r\n                                  <p style=\"line-height: 140%\">Me respekt,</p>\r\n                                  <p style=\"line-height: 140%\"> </p>\r\n                                  <p style=\"line-height: 140%\">Me respekt,</p>\r\n                                  <p style=\"line-height: 140%\">\r\n                                    Ekipi i Stud.io\r\n                                  </p>\r\n                                </div>\r\n                              </td>\r\n                            </tr>\r\n                          </tbody>\r\n                        </table>\r\n\r\n                        <!--[if (!mso)&(!IE)]><!-->\r\n                      </div>\r\n                      <!--<![endif]-->\r\n                    </div>\r\n                  </div>\r\n                  <!--[if (mso)|(IE)]></td><![endif]-->\r\n                  <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\r\n                </div>\r\n              </div>\r\n            </div>\r\n\r\n            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n    <!--[if mso]></div><![endif]-->\r\n    <!--[if IE]></div><![endif]-->\r\n  </body>\r\n</html>\r\n" };

            // send email using
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("rh52741@ubt-uni.net", "Rreziubt124");
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}