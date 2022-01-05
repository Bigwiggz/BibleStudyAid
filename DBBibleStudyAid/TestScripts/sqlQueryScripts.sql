
--Query Scripts


SELECT * 
FROM tblDailyBibleReading
LEFT JOIN tblReferences ON PKIdtblDailyBibleReadings=[tblReferences].FKTableIdandName
LEFT JOIN tblScriptures ON PKIdtblDailyBibleReadings=[tblScriptures].FKTableIdandName
LEFT JOIN tblTagsToOtherTables ON PKIdtblDailyBibleReadings=[tblTagsToOtherTables].FKTableIdandName;

