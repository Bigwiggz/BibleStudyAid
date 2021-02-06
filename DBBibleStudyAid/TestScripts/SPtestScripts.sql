
EXEC dbo.spCreateTag @TagName = 'Faith', @TagDescription='Any tag having to deal with Faith as defined in Heb 12:1';
--WORKED


EXEC dbo.spCreateReference
    @Reference='w 15/3 2004';
--WORKED

EXEC dbo.spCreateDailyBibleReading
	@ScriptureStartPoint ='Exodus 1:1', 
    @ScriptureEndPoint ='Exodus 1:20', 
    @LessonLearnedDescription ='Jehová apoyó a su pueblo cuando este se hallaba oprimido en Egipto. De igual manera, sostiene a sus Testigos de la actualidad, incluso cuando afrontan cruel persecución.', 
    @ReferenceId =1, 
    @DateRead ='2021-02-06';