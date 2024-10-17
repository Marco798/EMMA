namespace EMMA.Commons.UpdateSingleField {
    public class UpdateIntFieldData(string tableName, string fieldName, int fieldValue, long id) {
        public string TableName { get; set; } = tableName;
        public string FieldName { get; set; } = fieldName;
        public int FieldValue { get; set; } = fieldValue;
        public long Id { get; set; } = id;
    }
}
