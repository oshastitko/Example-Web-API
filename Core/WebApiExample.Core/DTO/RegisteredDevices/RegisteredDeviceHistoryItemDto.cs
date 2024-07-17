﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.RegisteredDevices
{
    public class RegisteredDeviceHistoryItemDto
    {
        public RegisteredDeviceFieldNameDto FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanges { get; set; }
    }
}
