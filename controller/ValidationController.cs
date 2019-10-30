﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Controls;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Universitätsverwaltung.controller
{
    public class ValidationController
    {
        public bool[] ValidAttributes { get; set; }
        public Label Lbl_error_msg { get; set; }
        public Button Btn_save { get; set; }

        public ValidationController(bool[] validAttributes, Label lbl_error_msg, Button btn_save)
        {
            ValidAttributes = validAttributes;
            Lbl_error_msg = lbl_error_msg;
            Btn_save = btn_save;
        }

        public bool IsValidAttribute(int valID, Type type, Control control, string value, string propertyName, string displayName)
        {
            ValidationContext validationContext = new ValidationContext(control);
            validationContext.DisplayName = displayName;
            List<ValidationResult> validationResults = new List<ValidationResult>();
            List<ValidationAttribute> validationAttributes = type.GetProperty(propertyName).GetCustomAttributes(false).OfType<ValidationAttribute>().ToList();

            ValidAttributes[valID] = Validator.TryValidateValue(value, validationContext, validationResults, validationAttributes);

            switch (validationResults.Count)
            {
                case 0:
                    Lbl_error_msg.Content = "";
                    break;
                default:
                    Lbl_error_msg.Content = validationResults[0].ErrorMessage;
                    break;
            }

            return ValidAttributes[valID];
        }

        public bool IsValidObject()
        {
            bool isValidObject = true;

            for (int i = 0; i < ValidAttributes.Length; i++)
            {
                if (!ValidAttributes[i])
                {
                    isValidObject = false;
                    break;
                }
            }

            return isValidObject;
        }

        public void ResetValidAttributes(bool reset)
        {
            for (int i = 0; i < ValidAttributes.Length; i++)
            {
                ValidAttributes[i] = reset;
            }
        }
    }

    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime result = new DateTime();
            return DateTime.TryParse(value.ToString(), out result);
        }
    }

    public class IntegerAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int result = -1;
            return int.TryParse(value.ToString(), out result);
        }
    }
}