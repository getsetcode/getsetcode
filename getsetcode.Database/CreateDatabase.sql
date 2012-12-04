USE [EmptyDatabase]
GO

CREATE TABLE [dbo].[Project]
(
	[ProjectId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[ShortName] [varchar] (25) COLLATE Latin1_General_CI_AS NOT NULL,
	[BriefSummary] [varchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
	[SummaryHtml] [varchar] (max) COLLATE Latin1_General_CI_AS NOT NULL,
	[ThumbnailImageId] [int] NULL,
	[Featured] [bit] NOT NULL,
	[ClientId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED
	(
		[ProjectId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_ShortName] ON [dbo].[Project]
(
	[ShortName] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ProjectContract]
(
	[ContractId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	CONSTRAINT [PK_ProjectContract] PRIMARY KEY CLUSTERED
	(
		[ContractId] ASC,
		[ProjectId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProjectImage]
(
	[ProjectId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[Rank] [tinyint] NOT NULL,
	CONSTRAINT [PK_ProjectImage] PRIMARY KEY CLUSTERED
	(
		[ProjectId] ASC,
		[ImageId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Person]
(
	[PersonId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
	[OfficePhone] [varchar] (20) COLLATE Latin1_General_CI_AS NULL,
	[MobilePhone] [varchar] (20) COLLATE Latin1_General_CI_AS NULL,
	[EmailAddress] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_AgencyContact_Active] DEFAULT ((1)),
	[ThumbnailId] [int] NULL,
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		[PersonId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Frequency]
(
	[FrequencyId] [tinyint] NOT NULL,
	[Text] [varchar] (20) COLLATE Latin1_General_CI_AS NOT NULL,
	CONSTRAINT [PK_Frequency] PRIMARY KEY CLUSTERED
	(
		[FrequencyId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[History]
(
	[HistoryId] [int] IDENTITY (1,1) NOT NULL,
	[DateStamp] [datetime] NOT NULL,
	[ProjectId] [int] NULL,
	[ClientId] [int] NULL,
	[TestimonialId] [int] NULL,
	CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED
	(
		[HistoryId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Image]
(
	[ImageId] [int] IDENTITY (1,1) NOT NULL,
	[Title] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[FileName] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[ThumbnailId] [int] NULL,
	CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED
	(
		[ImageId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SkillCategory]
(
	[SkillCategoryId] [tinyint] NOT NULL,
	[SkillCategory] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Rank] [tinyint] NOT NULL,
	CONSTRAINT [PK_SkillCategory] PRIMARY KEY CLUSTERED
	(
		[SkillCategoryId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[sysdiagrams]
(
	[name] [sysname] COLLATE Latin1_General_CI_AS NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY (1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary] (max) NULL,
	CONSTRAINT [PK__sysdiagr__C2B05B610EA330E9] PRIMARY KEY CLUSTERED
	(
		[diagram_id] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED
	(
		[name] ASC,
		[principal_id] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Testimonial]
(
	[TestimonialId] [int] IDENTITY (1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[ClientId] [int] NULL,
	[Role] [varchar] (100) COLLATE Latin1_General_CI_AS NULL,
	[Quote] [varchar] (max) COLLATE Latin1_General_CI_AS NOT NULL,
	[Date] [date] NOT NULL,
	CONSTRAINT [PK_Testimonial] PRIMARY KEY CLUSTERED
	(
		[TestimonialId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Skill]
(
	[SkillId] [int] IDENTITY (1,1) NOT NULL,
	[SkillCategoryId] [tinyint] NOT NULL,
	[Name] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[ShortName] [varchar] (10) COLLATE Latin1_General_CI_AS NOT NULL,
	[Summary] [varchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
	[DateAcquired] [date] NOT NULL,
	[CurrentVersion] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
	[IsCoreSkill] [bit] NOT NULL,
	[Rank] [tinyint] NOT NULL,
	CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED
	(
		[SkillId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_ShortName] ON [dbo].[Skill]
(
	[ShortName] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ProjectResponsibility]
(
	[ResponsibilityId] [int] IDENTITY (1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Description] [varchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
	[Rank] [tinyint] NOT NULL,
	CONSTRAINT [PK_ProjectResponsibility] PRIMARY KEY CLUSTERED
	(
		[ResponsibilityId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProjectSkill]
(
	[ProjectId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
	[Rank] [tinyint] NOT NULL,
	[Featured] [bit] NOT NULL,
	CONSTRAINT [PK_ProjectSkill] PRIMARY KEY CLUSTERED
	(
		[ProjectId] ASC,
		[SkillId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Rate]
(
	[RateId] [int] IDENTITY (1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[FrequencyId] [tinyint] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED
	(
		[RateId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ContactFormSubmission]
(
	[SubmissionId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
	[EmailAddress] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
	[Message] [varchar] (max) COLLATE Latin1_General_CI_AS NOT NULL,
	[MailingList] [bit] NOT NULL,
	[DateStamp] [datetime] NOT NULL,
	[EmailSent] [bit] NOT NULL,
	CONSTRAINT [PK_ContactFormSubmission] PRIMARY KEY CLUSTERED
	(
		[SubmissionId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Agency]
(
	[AgencyId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
	[Address] [varchar] (255) COLLATE Latin1_General_CI_AS NULL,
	[Phone] [varchar] (20) COLLATE Latin1_General_CI_AS NULL,
	[Email] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
	[PrimaryContactId] [int] NULL,
	CONSTRAINT [PK_Agency] PRIMARY KEY CLUSTERED
	(
		[AgencyId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AgencyPerson]
(
	[AgencyId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	CONSTRAINT [PK_AgencyPerson] PRIMARY KEY CLUSTERED
	(
		[AgencyId] ASC,
		[PersonId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Contract]
(
	[ContractId] [int] IDENTITY (1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[AgencyId] [int] NULL,
	[ContactDetails] [varchar] (255) COLLATE Latin1_General_CI_AS NULL,
	[WorkDetails] [varchar] (max) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED
	(
		[ContractId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClientPerson]
(
	[ClientId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	CONSTRAINT [PK_ClientPerson] PRIMARY KEY CLUSTERED
	(
		[ClientId] ASC,
		[PersonId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CurriculumVitae]
(
	[Version] [float] NOT NULL,
	[FileName] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
	[WordVersion] [bit] NOT NULL,
	[PdfVersion] [bit] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	CONSTRAINT [PK_CurriculumVitae] PRIMARY KEY CLUSTERED
	(
		[Version] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Client]
(
	[ClientId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
	[ShortName] [varchar] (10) COLLATE Latin1_General_CI_AS NOT NULL,
	[Address] [varchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
	[BriefDescription] [varchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
	[SummaryHtml] [varchar] (max) COLLATE Latin1_General_CI_AS NULL,
	[Website] [varchar] (100) COLLATE Latin1_General_CI_AS NULL,
	[LogoId] [int] NULL,
	[Featured] [bit] NOT NULL,
	CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED
	(
		[ClientId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_ShortName] ON [dbo].[Client]
(
	[ShortName] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
GO
ALTER TABLE [dbo].[Rate] ADD CONSTRAINT [FK_Rate_Contract] FOREIGN KEY
	(
		[ContractId]
	)
	REFERENCES [dbo].[Contract]
	(
		[ContractId]
	)
GO

ALTER TABLE [dbo].[Rate] ADD CONSTRAINT [FK_Rate_Frequency] FOREIGN KEY
	(
		[FrequencyId]
	)
	REFERENCES [dbo].[Frequency]
	(
		[FrequencyId]
	)
GO

ALTER TABLE [dbo].[ProjectSkill] ADD CONSTRAINT [FK_ProjectSkill_Project] FOREIGN KEY
	(
		[ProjectId]
	)
	REFERENCES [dbo].[Project]
	(
		[ProjectId]
	)
GO

ALTER TABLE [dbo].[ProjectSkill] ADD CONSTRAINT [FK_ProjectSkill_Skill] FOREIGN KEY
	(
		[SkillId]
	)
	REFERENCES [dbo].[Skill]
	(
		[SkillId]
	)
GO

ALTER TABLE [dbo].[AgencyPerson] ADD CONSTRAINT [FK_AgencyPerson_Agency] FOREIGN KEY
	(
		[AgencyId]
	)
	REFERENCES [dbo].[Agency]
	(
		[AgencyId]
	)
GO

ALTER TABLE [dbo].[AgencyPerson] ADD CONSTRAINT [FK_AgencyPerson_Person] FOREIGN KEY
	(
		[PersonId]
	)
	REFERENCES [dbo].[Person]
	(
		[PersonId]
	)
GO

ALTER TABLE [dbo].[Skill] ADD CONSTRAINT [FK_Skill_SkillCategory] FOREIGN KEY
	(
		[SkillCategoryId]
	)
	REFERENCES [dbo].[SkillCategory]
	(
		[SkillCategoryId]
	)
GO

ALTER TABLE [dbo].[Testimonial] ADD CONSTRAINT [FK_Testimonial_Client] FOREIGN KEY
	(
		[ClientId]
	)
	REFERENCES [dbo].[Client]
	(
		[ClientId]
	)
GO

ALTER TABLE [dbo].[Testimonial] ADD CONSTRAINT [FK_Testimonial_Person] FOREIGN KEY
	(
		[PersonId]
	)
	REFERENCES [dbo].[Person]
	(
		[PersonId]
	)
GO

ALTER TABLE [dbo].[Agency] ADD CONSTRAINT [FK_Agency_Person] FOREIGN KEY
	(
		[PrimaryContactId]
	)
	REFERENCES [dbo].[Person]
	(
		[PersonId]
	)
GO

ALTER TABLE [dbo].[Image] ADD CONSTRAINT [FK_Image_Image] FOREIGN KEY
	(
		[ThumbnailId]
	)
	REFERENCES [dbo].[Image]
	(
		[ImageId]
	)
GO

ALTER TABLE [dbo].[Person] ADD CONSTRAINT [FK_Person_Image] FOREIGN KEY
	(
		[ThumbnailId]
	)
	REFERENCES [dbo].[Image]
	(
		[ImageId]
	)
GO

ALTER TABLE [dbo].[History] ADD CONSTRAINT [FK_History_Client] FOREIGN KEY
	(
		[ClientId]
	)
	REFERENCES [dbo].[Client]
	(
		[ClientId]
	)
GO

ALTER TABLE [dbo].[History] ADD CONSTRAINT [FK_History_Project] FOREIGN KEY
	(
		[ProjectId]
	)
	REFERENCES [dbo].[Project]
	(
		[ProjectId]
	)
GO

ALTER TABLE [dbo].[History] ADD CONSTRAINT [FK_History_Testimonial] FOREIGN KEY
	(
		[TestimonialId]
	)
	REFERENCES [dbo].[Testimonial]
	(
		[TestimonialId]
	)
GO

ALTER TABLE [dbo].[Contract] ADD CONSTRAINT [FK_Contract_Agency] FOREIGN KEY
	(
		[AgencyId]
	)
	REFERENCES [dbo].[Agency]
	(
		[AgencyId]
	)
GO

ALTER TABLE [dbo].[Contract] ADD CONSTRAINT [FK_Contract_Organisation] FOREIGN KEY
	(
		[ClientId]
	)
	REFERENCES [dbo].[Client]
	(
		[ClientId]
	)
GO

ALTER TABLE [dbo].[ProjectImage] ADD CONSTRAINT [FK_ProjectImage_Image] FOREIGN KEY
	(
		[ImageId]
	)
	REFERENCES [dbo].[Image]
	(
		[ImageId]
	)
GO

ALTER TABLE [dbo].[ProjectImage] ADD CONSTRAINT [FK_ProjectImage_Project] FOREIGN KEY
	(
		[ProjectId]
	)
	REFERENCES [dbo].[Project]
	(
		[ProjectId]
	)
GO

ALTER TABLE [dbo].[ProjectResponsibility] ADD CONSTRAINT [FK_ProjectResponsibility_Project] FOREIGN KEY
	(
		[ProjectId]
	)
	REFERENCES [dbo].[Project]
	(
		[ProjectId]
	)
GO

ALTER TABLE [dbo].[Client] ADD CONSTRAINT [FK_Client_Image] FOREIGN KEY
	(
		[LogoId]
	)
	REFERENCES [dbo].[Image]
	(
		[ImageId]
	)
GO

ALTER TABLE [dbo].[Project] ADD CONSTRAINT [FK_Project_Client] FOREIGN KEY
	(
		[ClientId]
	)
	REFERENCES [dbo].[Client]
	(
		[ClientId]
	)
GO

ALTER TABLE [dbo].[Project] ADD CONSTRAINT [FK_Project_Image] FOREIGN KEY
	(
		[ThumbnailImageId]
	)
	REFERENCES [dbo].[Image]
	(
		[ImageId]
	)
GO

ALTER TABLE [dbo].[ProjectContract] ADD CONSTRAINT [FK_ProjectContract_Contract] FOREIGN KEY
	(
		[ContractId]
	)
	REFERENCES [dbo].[Contract]
	(
		[ContractId]
	)
GO

ALTER TABLE [dbo].[ProjectContract] ADD CONSTRAINT [FK_ProjectContract_Project] FOREIGN KEY
	(
		[ProjectId]
	)
	REFERENCES [dbo].[Project]
	(
		[ProjectId]
	)
GO

ALTER TABLE [dbo].[ClientPerson] ADD CONSTRAINT [FK_ClientPerson_Client] FOREIGN KEY
	(
		[ClientId]
	)
	REFERENCES [dbo].[Client]
	(
		[ClientId]
	)
GO

ALTER TABLE [dbo].[ClientPerson] ADD CONSTRAINT [FK_ClientPerson_Person] FOREIGN KEY
	(
		[PersonId]
	)
	REFERENCES [dbo].[Person]
	(
		[PersonId]
	)
GO

CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_alterdiagram'
GO

CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_dropdiagram'
GO

CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_helpdiagrams'
GO

CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_renamediagram'
GO

CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_upgraddiagrams'
GO

CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_helpdiagramdefinition'
GO

CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=N'1' ,@level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'PROCEDURE',@level1name=N'sp_creatediagram'
GO

