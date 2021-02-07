EXEC [dbo].[spCreateReferences] @Reference='w2011 1/3 p2';
--WORKING

EXEC [dbo].[spCreatePersonalStudyFindings]

    @Scripture ='Exodus 1:1-20',
    @Explanation='Jehová apoyó a su pueblo cuando este se hallaba oprimido en Egipto. De igual manera, sostiene a sus Testigos de la actualidad, incluso cuando afrontan cruel persecución.',
    @ReferenceId =1;
--WORKING

EXEC [dbo].[spCreatePersonalStudyProjects]
    @PersonalStudyTitle='A Test Study of Exodus' , 
    @PersonalStudyDescription='This is a test study of Exodus as a book.  An examination of the Nation of Isrealites and how they were freed from Egypt.', 
    @PersonalStudyQuestionAssignment='How does the example of the Isrealites in Egypt apply to me today?', 
    @DateFinished ='2021-02-06', 
    @Scripture='Exodus 1-40', 
    @PersonalStudyFindingsId =2;
--WORKING

SELECT * FROM [dbo].[tblMeetingType];

EXEC [dbo].[spCreateMeetingType]
    @MeetingTypeName='Public Talk',
    @MeetingTypeDescription='30 minute Public Talk';
--WORKING

EXEC [dbo].[spCreateMeetingAssemblies]
    @DateOfMeeting='2021-02-06', 
    @PartTitle='Telephone Witnessing', 
    @MeetingTypeId =1, 
    @Scripture='Acts 20:24', 
    @ReferenceId=NULL, 
    @LessonLearnedDescription='We need to preach more over the phone.  It is a great way to conduct Bible Studies.';

--WORKING

EXEC [dbo].[spCreateTagsToOtherTables]
    @TagsId=1, 
    @tblId=1, 
    @tblName ='MeetingAssemblies', 
    @FKtblIdAndName='1tblMeetingAssemblies';
--WORKING

DECLARE @File VARBINARY(MAX)
SET @File=(SELECT * FROM OPENROWSET(BULK 'D:\Documents\temp\TestTalk.txt', SINGLE_BLOB) AS BLOB );

EXEC [dbo].[spCreateTalk]
    @TalkTitle ='Test Talk Added', 
    @DateGiven ='2021-02-06',  
    @MeetingTypeId=2, 
    @Description='This is a test talk description', 
    @TalkDocument=@File, 
    @ThemeScripture='Jude 3',
    @ReferenceId=3;
--NOT WORKING