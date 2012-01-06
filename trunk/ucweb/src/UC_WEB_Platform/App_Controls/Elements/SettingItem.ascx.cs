using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;




namespace UCENTRIK.WEB.PLATFORM.App_Controls.Elements
{
    public partial class SettingItem : UcAppBaseControl
    {


        public enum EnumSettingTypes
        {
            enumText = 1,
            enumInt = 2,
            enumBool = 3,
            enumUrl = 4
        }




        private EnumSettingTypes _settingType;
        public EnumSettingTypes SettingType
        {
            set
            {
                _settingType = value;

                //switch (_settingType)
                //{
                //    case EnumSettingTypes.enumText:
                //        valSettingValue.ValidationExpression = @"/[a-zA-Z0-9]/";
                //        break;

                //    case EnumSettingTypes.enumInt:
                //        valSettingValue.ValidationExpression = @"[^0-9-]";
                //        break;

                //    case EnumSettingTypes.enumBool:
                //        valSettingValue.ValidationExpression = @"[Tt]rue|[Ff]alse";
                //        break;

                //    case EnumSettingTypes.enumUrl:
                //        valSettingValue.ValidationExpression = @"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))[\w\d:#%/;$()~_?\-=\\\.&]*)";
                //        break;

                //    default:
                //        valSettingValue.ValidationExpression = "";
                //        break;

                //}

            }
        }

        public string SettingCategory
        { 
            set
            {
                hfSettingCategory.Value = value;
            }
        }

        public string SettingName
        {
            set
            {
                lblName.Text = value;
            }
        }
        public string SettingValue
        {
            set
            {
                txtValue.Text = value;
            }
        }
        public string SettingTooltip
        {
            set
            {
                txtValue.ToolTip = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            //string script = btnSave.ClientID + ".disabled=false";
            //txtValue.Attributes.Add("onclick", script);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            string s = txtValue.Text;

            //switch(_settingType)
            //{
            //    case EnumSettingTypes.enumText:
            //        isValid = true;
            //        break;

            //    case EnumSettingTypes.enumInt:
            //        Int32 i = 0;
            //        isValid = Int32.TryParse(s, out i);
            //        break;

            //    case EnumSettingTypes.enumBool:
            //        bool b = false; ;
            //        isValid = bool.TryParse(s, out b);
            //        break;

            //    case EnumSettingTypes.enumUrl:
            //        isValid = true;
            //        break;

            //    default:
            //        break;

            //}


            isValid = true;

            if (isValid)
            {
                BllProxySettings.SetSetting(lblName.Text, hfSettingCategory.Value, txtValue.Text);
                lblMessage.Text = "Saved";
            }
            else
            {

            }


        }



        //---
    }
}