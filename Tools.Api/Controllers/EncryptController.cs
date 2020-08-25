using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tool.Entity.Model;
using Tools.Common;

namespace Tools.Api.Controllers
{
    public class EncryptController : Controller
    {
        private readonly ILogger<EncryptController> _logger;

        public EncryptController(ILogger<EncryptController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "get")]
        public JsonResult Get()
        {
            return Json(new { Message = "Ok", IsSussecc = true });
        }

        [HttpGet]
        public BaseResponse<string> DESEncrypt(string text, string key, string iv)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(iv))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                if (!string.IsNullOrEmpty(iv))
                {
                    if (iv.Length != 8)
                    {
                        result.Code = -1;
                        result.Message = string.Format("初始化向量参数长度只能是8位字符");
                        return result;
                    }
                    result.Data = EncryptHelper.DESEncrypt(text, key, iv);
                }
                else
                {
                    result.Data = EncryptHelper.DesEncrypt(text, key);
                }
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("DESEncrypt异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> DESDecrypst(string text, string key, string iv)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                if (!string.IsNullOrEmpty(iv))
                {
                    if (iv.Length != 8)
                    {
                        result.Code = -1;
                        result.Message = string.Format("初始化向量参数长度只能是8位字符");
                        return result;
                    }
                    result.Data = EncryptHelper.DESDecrypst(text, key, iv);
                }
                else
                {
                    result.Data = EncryptHelper.DesDecrypt(text, key);
                }

                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("DESDecrypst异常:{0}", ex.Message);
            }
            return result;
        }




        [HttpGet]
        public BaseResponse<string> AESEncrypt(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.AES_Encrypt(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("AESEncrypt异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> AESDecrypt(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                result.Data = EncryptHelper.AES_Decrypt(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("AESDecrypt异常:{0}", ex.Message);
            }
            return result;
        }
        [HttpGet]
        public BaseResponse<string> AESEncryptECB(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.AESEncryptECB(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("AESEncryptECB异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> AESDecryptECB(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                result.Data = EncryptHelper.AESDecryptECB(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("AESDecryptECB异常:{0}", ex.Message);
            }
            return result;
        }
        [HttpGet]
        public BaseResponse<string> EncryptByRSA(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                result.Data = EncryptHelper.EncryptByRSA(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("EncryptByRSA异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> DecryptByRSA(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                result.Data = EncryptHelper.DecryptByRSA(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("DecryptByRSA异常:{0}", ex.Message);
            }
            return result;
        }
        [HttpGet]
        public BaseResponse<string> Base64Encrypt(string text)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.Base64Encrypt(text);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("Base64Encrypt异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> Base64Decrypt(string text)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.Base64Decrypt(text);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("Base64Decrypt常:{0}", ex.Message);
            }
            return result;
        }




        [HttpGet]
        public BaseResponse<string> GetMD5(string text, int Length = 8)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }
                if (!new int[] { 4, 8, 16, 32 }.Contains(Length))
                {
                    result.Code = -1;
                    result.Message = string.Format("仅支持，4、8、16、32");
                    return result;
                }
                switch (Length)
                {
                    case 32:
                        result.Data = EncryptHelper.GetMD5_32(text);
                        break;
                    case 16:
                        result.Data = EncryptHelper.GetMD5_16(text);
                        break;
                    case 8:
                        result.Data = EncryptHelper.GetMD5_8(text);
                        break;
                    case 4:
                        result.Data = EncryptHelper.GetMD5_4(text);
                        break;
                }
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("GetMD5异常:{0}", ex.Message);
            }
            return result;
        }

        [HttpGet]
        public BaseResponse<string> SHA256(string text)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.SHA256(text);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("SHA256异常:{0}", ex.Message);
            }
            return result;
        }

        [HttpGet]
        public BaseResponse<string> EncryptRC4wq(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.EncryptRC4wq(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("EncryptRC4wq异常:{0}", ex.Message);
            }
            return result;
        }



        [HttpGet]
        public BaseResponse<string> DecryptRC4wq(string text, string key)
        {
            var result = new BaseResponse<string>();
            try
            {
                if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
                {
                    result.Code = -1;
                    result.Message = string.Format("入参信息不可为空");
                    return result;
                }

                result.Data = EncryptHelper.DecryptRC4wq(text, key);
                result.Message = string.Format("操作成功");
            }
            catch (Exception ex)
            {
                result.Code = -9;
                result.Message = string.Format("DecryptRC4wq异常:{0}", ex.Message);
            }
            return result;
        }
    }
}