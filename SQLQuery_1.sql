-- Add a new column '[NewColumnName]' to table '[TableName]' in schema '[dbo]'
ALTER TABLE [dbo].[TableName]
    ADD [NewColumnName] /*new_column_name*/ int /*new_column_datatype*/ NULL /*new_column_nullability*/
GO