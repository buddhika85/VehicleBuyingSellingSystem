use VehicleMgmt;

--INSERT INTO [dbo].[Manufacturers] VALUES ('Toyota', 'Japan');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Ford', 'USA');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Honda', 'Japan');
--INSERT INTO [dbo].[Manufacturers] VALUES ('BMW', 'Germany');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Mercedes-Benz', 'Germany');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Chevrolet', 'USA');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Nissan', 'Japan');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Volkswagen', 'Germany');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Hyundai', 'South Korea');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Ferrari', 'Italy');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Volvo', 'Sweden');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Kia', 'South Korea');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Audi', 'Germany');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Lamborghini', 'Italy');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Porsche', 'Germany');
--INSERT INTO [dbo].[Manufacturers] VALUES ('Tesla', 'USA');

select * from Manufacturers;

select * from Vehicles;


INSERT INTO [dbo].[Vehicles]           ([ManufacturerId]           ,[MakeYear]           ,[Model]           ,[Type]           ,[VehicleCondition]           ,[Price]           ,[StateLocated]           ,[Views]           ,[Description])
     VALUES           (1           ,2024           ,'Yaris'           ,1           ,3           ,24000           ,1           ,0           ,'Yaris 2024')


