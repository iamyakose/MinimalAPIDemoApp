if not exists (select 1 from dbo.[User])
begin
  insert into dbo.[User] (FirstName, LastName)
  values ('Yemi', 'Oseni'),
   ('Sue', 'Storm'),
   ('Cassy', 'Larssy'),
   ('Andrew', 'Tijani');
end