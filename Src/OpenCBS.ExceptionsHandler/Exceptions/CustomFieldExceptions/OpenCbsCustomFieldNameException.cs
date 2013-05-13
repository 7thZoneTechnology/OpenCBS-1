﻿// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using OpenCBS.Enums;


namespace OpenCBS.ExceptionsHandler.Exceptions.CustomFieldExceptions
{
    [Serializable]
    public class OpenCbsCustomFieldNameException:OpenCbsException
    {
        private readonly string _message;

        public OpenCbsCustomFieldNameException(OCustomFieldExceptionEnum customFieldNameException)
        {
            _message = FindExceptionMessage(customFieldNameException);
        }

        private string FindExceptionMessage(OCustomFieldExceptionEnum customFieldExceptionEnum)
        {
            string message = string.Empty;
            switch (customFieldExceptionEnum)
            {
                case OCustomFieldExceptionEnum.FieldNameCanNotContainComma:
                    message = "FieldNameCanNotContainComma.Text";
                    break;
                case OCustomFieldExceptionEnum.FieldLimited:
                    message = "FieldLimited.Text";
                    break;
                default: break;
            }
            return message;
        }

        public override string ToString()
        {
            return _message;
        }
    }
}
