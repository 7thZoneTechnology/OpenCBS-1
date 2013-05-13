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

namespace OpenCBS.CoreDomain.DataSet
{
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class DataSetElementaryMvts : DataSet {
        
        private ElementaryMvtsDataTable tableElementaryMvts;
        
        public DataSetElementaryMvts() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected DataSetElementaryMvts(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["ElementaryMvts"] != null)) {
                    this.Tables.Add(new ElementaryMvtsDataTable(ds.Tables["ElementaryMvts"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ElementaryMvtsDataTable ElementaryMvts {
            get {
                return this.tableElementaryMvts;
            }
        }
        
        public override DataSet Clone() {
            DataSetElementaryMvts cln = ((DataSetElementaryMvts)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["ElementaryMvts"] != null)) {
                this.Tables.Add(new ElementaryMvtsDataTable(ds.Tables["ElementaryMvts"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableElementaryMvts = ((ElementaryMvtsDataTable)(this.Tables["ElementaryMvts"]));
            if ((this.tableElementaryMvts != null)) {
                this.tableElementaryMvts.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "DataSetElementaryMvts";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/DataSetElementaryMvts.xsd";
            this.Locale = new System.Globalization.CultureInfo("fr-FR");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableElementaryMvts = new ElementaryMvtsDataTable();
            this.Tables.Add(this.tableElementaryMvts);
        }
        
        private bool ShouldSerializeElementaryMvts() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void ElementaryMvtsRowChangeEventHandler(object sender, ElementaryMvtsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ElementaryMvtsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnDate;
            
            private DataColumn columnAccount_number_debit;
            
            private DataColumn columnAccount_number_credit;
            
            private DataColumn columnAmount;
            
            private DataColumn columnCurrency_code;
            
            private DataColumn columnUsername;
            
            private DataColumn columnEvent_code;
            
            private DataColumn columnFunding_line;
            
            private DataColumn columnNumber;
            
            private DataColumn columnMovement_set_id;
            
            internal ElementaryMvtsDataTable() : 
                    base("ElementaryMvts") {
                this.InitClass();
            }
            
            internal ElementaryMvtsDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn DateColumn {
                get {
                    return this.columnDate;
                }
            }
            
            internal DataColumn Account_number_debitColumn {
                get {
                    return this.columnAccount_number_debit;
                }
            }
            
            internal DataColumn Account_number_creditColumn {
                get {
                    return this.columnAccount_number_credit;
                }
            }
            
            internal DataColumn AmountColumn {
                get {
                    return this.columnAmount;
                }
            }
            
            internal DataColumn Currency_codeColumn {
                get {
                    return this.columnCurrency_code;
                }
            }
            
            internal DataColumn UsernameColumn {
                get {
                    return this.columnUsername;
                }
            }
            
            internal DataColumn Event_codeColumn {
                get {
                    return this.columnEvent_code;
                }
            }
            
            internal DataColumn Funding_lineColumn {
                get {
                    return this.columnFunding_line;
                }
            }
            
            internal DataColumn NumberColumn {
                get {
                    return this.columnNumber;
                }
            }
            
            internal DataColumn Movement_set_idColumn {
                get {
                    return this.columnMovement_set_id;
                }
            }
            
            public ElementaryMvtsRow this[int index] {
                get {
                    return ((ElementaryMvtsRow)(this.Rows[index]));
                }
            }
            
            public event ElementaryMvtsRowChangeEventHandler ElementaryMvtsRowChanged;
            
            public event ElementaryMvtsRowChangeEventHandler ElementaryMvtsRowChanging;
            
            public event ElementaryMvtsRowChangeEventHandler ElementaryMvtsRowDeleted;
            
            public event ElementaryMvtsRowChangeEventHandler ElementaryMvtsRowDeleting;
            
            public void AddElementaryMvtsRow(ElementaryMvtsRow row) {
                this.Rows.Add(row);
            }
            
            public ElementaryMvtsRow AddElementaryMvtsRow(string Date, string Account_number_debit, string Account_number_credit, System.Decimal Amount, string Currency_code, string Username, string Event_code, string Funding_line, int Number, int Movement_set_id) {
                ElementaryMvtsRow rowElementaryMvtsRow = ((ElementaryMvtsRow)(this.NewRow()));
                rowElementaryMvtsRow.ItemArray = new object[] {
                        Date,
                        Account_number_debit,
                        Account_number_credit,
                        Amount,
                        Currency_code,
                        Username,
                        Event_code,
                        Funding_line,
                        Number,
                        Movement_set_id};
                this.Rows.Add(rowElementaryMvtsRow);
                return rowElementaryMvtsRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                ElementaryMvtsDataTable cln = ((ElementaryMvtsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new ElementaryMvtsDataTable();
            }
            
            internal void InitVars() {
                this.columnDate = this.Columns["Date"];
                this.columnAccount_number_debit = this.Columns["Account_number_debit"];
                this.columnAccount_number_credit = this.Columns["Account_number_credit"];
                this.columnAmount = this.Columns["Amount"];
                this.columnCurrency_code = this.Columns["Currency_code"];
                this.columnUsername = this.Columns["Username"];
                this.columnEvent_code = this.Columns["Event_code"];
                this.columnFunding_line = this.Columns["Funding_line"];
                this.columnNumber = this.Columns["Number"];
                this.columnMovement_set_id = this.Columns["Movement_set_id"];
            }
            
            private void InitClass() {
                this.columnDate = new DataColumn("Date", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnDate);
                this.columnAccount_number_debit = new DataColumn("Account_number_debit", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAccount_number_debit);
                this.columnAccount_number_credit = new DataColumn("Account_number_credit", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAccount_number_credit);
                this.columnAmount = new DataColumn("Amount", typeof(System.Decimal), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAmount);
                this.columnCurrency_code = new DataColumn("Currency_code", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCurrency_code);
                this.columnUsername = new DataColumn("Username", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUsername);
                this.columnEvent_code = new DataColumn("Event_code", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnEvent_code);
                this.columnFunding_line = new DataColumn("Funding_line", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnFunding_line);
                this.columnNumber = new DataColumn("Number", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnNumber);
                this.columnMovement_set_id = new DataColumn("Movement_set_id", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnMovement_set_id);
                this.columnDate.AllowDBNull = false;
                this.columnAmount.AllowDBNull = false;
                this.columnUsername.ReadOnly = true;
                this.columnEvent_code.ReadOnly = true;
                this.columnFunding_line.AllowDBNull = false;
            }
            
            public ElementaryMvtsRow NewElementaryMvtsRow() {
                return ((ElementaryMvtsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new ElementaryMvtsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(ElementaryMvtsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.ElementaryMvtsRowChanged != null)) {
                    this.ElementaryMvtsRowChanged(this, new ElementaryMvtsRowChangeEvent(((ElementaryMvtsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.ElementaryMvtsRowChanging != null)) {
                    this.ElementaryMvtsRowChanging(this, new ElementaryMvtsRowChangeEvent(((ElementaryMvtsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.ElementaryMvtsRowDeleted != null)) {
                    this.ElementaryMvtsRowDeleted(this, new ElementaryMvtsRowChangeEvent(((ElementaryMvtsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.ElementaryMvtsRowDeleting != null)) {
                    this.ElementaryMvtsRowDeleting(this, new ElementaryMvtsRowChangeEvent(((ElementaryMvtsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveElementaryMvtsRow(ElementaryMvtsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ElementaryMvtsRow : DataRow {
            
            private ElementaryMvtsDataTable tableElementaryMvts;
            
            internal ElementaryMvtsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableElementaryMvts = ((ElementaryMvtsDataTable)(this.Table));
            }
            
            public string Date {
                get {
                    return ((string)(this[this.tableElementaryMvts.DateColumn]));
                }
                set {
                    this[this.tableElementaryMvts.DateColumn] = value;
                }
            }
            
            public string Account_number_debit {
                get {
                    try {
                        return ((string)(this[this.tableElementaryMvts.Account_number_debitColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.Account_number_debitColumn] = value;
                }
            }
            
            public string Account_number_credit {
                get {
                    try {
                        return ((string)(this[this.tableElementaryMvts.Account_number_creditColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.Account_number_creditColumn] = value;
                }
            }
            
            public System.Decimal Amount {
                get {
                    return ((System.Decimal)(this[this.tableElementaryMvts.AmountColumn]));
                }
                set {
                    this[this.tableElementaryMvts.AmountColumn] = value;
                }
            }
            
            public string Currency_code {
                get {
                    try {
                        return ((string)(this[this.tableElementaryMvts.Currency_codeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.Currency_codeColumn] = value;
                }
            }
            
            public string Username {
                get {
                    try {
                        return ((string)(this[this.tableElementaryMvts.UsernameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.UsernameColumn] = value;
                }
            }
            
            public string Event_code {
                get {
                    try {
                        return ((string)(this[this.tableElementaryMvts.Event_codeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.Event_codeColumn] = value;
                }
            }
            
            public string Funding_line {
                get {
                    return ((string)(this[this.tableElementaryMvts.Funding_lineColumn]));
                }
                set {
                    this[this.tableElementaryMvts.Funding_lineColumn] = value;
                }
            }
            
            public int Number {
                get {
                    try {
                        return ((int)(this[this.tableElementaryMvts.NumberColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.NumberColumn] = value;
                }
            }
            
            public int Movement_set_id {
                get {
                    try {
                        return ((int)(this[this.tableElementaryMvts.Movement_set_idColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableElementaryMvts.Movement_set_idColumn] = value;
                }
            }
            
            public bool IsAccount_number_debitNull() {
                return this.IsNull(this.tableElementaryMvts.Account_number_debitColumn);
            }
            
            public void SetAccount_number_debitNull() {
                this[this.tableElementaryMvts.Account_number_debitColumn] = System.Convert.DBNull;
            }
            
            public bool IsAccount_number_creditNull() {
                return this.IsNull(this.tableElementaryMvts.Account_number_creditColumn);
            }
            
            public void SetAccount_number_creditNull() {
                this[this.tableElementaryMvts.Account_number_creditColumn] = System.Convert.DBNull;
            }
            
            public bool IsCurrency_codeNull() {
                return this.IsNull(this.tableElementaryMvts.Currency_codeColumn);
            }
            
            public void SetCurrency_codeNull() {
                this[this.tableElementaryMvts.Currency_codeColumn] = System.Convert.DBNull;
            }
            
            public bool IsUsernameNull() {
                return this.IsNull(this.tableElementaryMvts.UsernameColumn);
            }
            
            public void SetUsernameNull() {
                this[this.tableElementaryMvts.UsernameColumn] = System.Convert.DBNull;
            }
            
            public bool IsEvent_codeNull() {
                return this.IsNull(this.tableElementaryMvts.Event_codeColumn);
            }
            
            public void SetEvent_codeNull() {
                this[this.tableElementaryMvts.Event_codeColumn] = System.Convert.DBNull;
            }
            
            public bool IsNumberNull() {
                return this.IsNull(this.tableElementaryMvts.NumberColumn);
            }
            
            public void SetNumberNull() {
                this[this.tableElementaryMvts.NumberColumn] = System.Convert.DBNull;
            }
            
            public bool IsMovement_set_idNull() {
                return this.IsNull(this.tableElementaryMvts.Movement_set_idColumn);
            }
            
            public void SetMovement_set_idNull() {
                this[this.tableElementaryMvts.Movement_set_idColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ElementaryMvtsRowChangeEvent : EventArgs {
            
            private ElementaryMvtsRow eventRow;
            
            private DataRowAction eventAction;
            
            public ElementaryMvtsRowChangeEvent(ElementaryMvtsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public ElementaryMvtsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
