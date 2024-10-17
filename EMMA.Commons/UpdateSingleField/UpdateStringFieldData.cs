﻿namespace EMMA.Commons.UpdateSingleField {
    public class UpdateStringFieldData(string tableName, string fieldName, string fieldValue, long id) {
        public string TableName { get; set; } = tableName;
        public string FieldName { get; set; } = fieldName;
        public string FieldValue { get; set; } = fieldValue;
        public long Id { get; set; } = id;
    }
}
