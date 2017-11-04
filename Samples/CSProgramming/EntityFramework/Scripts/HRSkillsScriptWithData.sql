--------------------------------------------------------------
-- Copyright (c) Microsoft Corporation.  All rights reserved.
--------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO

IF EXISTS (SELECT * FROM sys.databases 
WHERE name = 'HRSkills')
DROP DATABASE HRSkills;
GO

-- Create the database.
CREATE DATABASE HRSkills;
GO

USE HRSkills;
GO

IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') 
AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[Employees](
    [EmployeeId] [uniqueidentifier] NOT NULL,
     [LastName] [nvarchar](50) NOT NULL,
     [FirstName] [nvarchar](50) NULL,
     [Alias] [nvarchar](50) NOT NULL,
     [Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
     [EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[SkillInfo]') 
AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[SkillInfo](
     [SkillInfoId] [uniqueidentifier] NOT NULL,
     [URL] [nvarchar](250) NOT NULL,
     [SkillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
     [SkillInfoId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[References]') 
AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[References](
     [ReferenceId] [uniqueidentifier] NOT NULL,
     [LastName] [nvarchar](50) NOT NULL,
     [FirstName] [nvarchar](50) NULL,
     [Position] [nvarchar](50) NULL,
     [Alias] [nvarchar](50) NOT NULL,
     [Email] [nvarchar](50) NULL,
     [EmployeeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
     [ReferenceId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Skills]') 
AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[Skills](
     [SkillId] [uniqueidentifier] NOT NULL,
     [EmployeeId] [uniqueidentifier] NOT NULL,
     [SkillName] [nvarchar](50) NOT NULL,
     [BriefDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
     [SkillId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys 
WHERE object_id = OBJECT_ID(N'[dbo].[SkillInfo_Skill]') 
AND parent_object_id = OBJECT_ID(N'[dbo].[SkillInfo]'))
ALTER TABLE [dbo].[SkillInfo]  
WITH CHECK ADD  CONSTRAINT [SkillInfo_Skill] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([SkillId])
GO
ALTER TABLE [dbo].[SkillInfo] CHECK CONSTRAINT [SkillInfo_Skill]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys 
WHERE object_id = OBJECT_ID(N'[dbo].[Reference_Employee]') 
AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))

ALTER TABLE [dbo].[References]  
WITH CHECK ADD  CONSTRAINT [Reference_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [Reference_Employee]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys 
WHERE object_id = OBJECT_ID(N'[dbo].[Skill_Employee]') 
AND parent_object_id = OBJECT_ID(N'[dbo].[Skills]'))
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [Skill_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT [Skill_Employee]
GO

USE HRSkills
GO

INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('a85006a6-8c60-4b22-a3b8-21cb11851305' AS uniqueidentifier), 'Rodman', 'John', 'jrodman', 'jrodman@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('660cfa74-a041-4988-8540-267f0f1cc379' AS uniqueidentifier), 'Bossard', 'David', 'dbossard', 'dbossard@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier), 'Aaberg', 'Jesper', 'jaaberg', 'jaaberg@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('24459614-fa32-4d2c-a133-363ba736643c' AS uniqueidentifier), 'Halberg', 'Pernille', 'phalberg', 'phalberg@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('94e4f274-0ea2-4c35-90a9-424006276b71' AS uniqueidentifier), 'Haas', 'Jonathan', 'jhaas', 'jhass@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('3e8e578c-6810-48bd-aadb-620edecf988c' AS uniqueidentifier), 'Kahn', 'Wendy', 'wkahn', 'wkahn@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('e8de2a50-9907-4147-89e7-7d643d677469' AS uniqueidentifier), 'Magnotta', 'Maureen', 'mmagnotta', 'mmagnotta@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('0c24972a-9746-4d3f-aaab-8c9fb7706525' AS uniqueidentifier), 'Paramasivam', 'Prakash', 'prakparam', 'prakparam@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('87e8e737-c56f-4e95-a8af-c0d6ae60532a' AS uniqueidentifier), 'Dickson', 'Holly', 'hdickson', 'hdickson@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('4c3631f8-2b98-45d7-8333-c13919d8bfa6' AS uniqueidentifier), 'Hadaya', 'Sagiv', 'shadaya', 'shadaya@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('00fcefa4-bf81-4674-81c1-c2de86f0c5f6' AS uniqueidentifier), 'Kim', 'Kari', 'kari3', 'kari3@adventure-works.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('1a20fc12-6ca1-46d2-b9dc-c5c42be8a2b1' AS uniqueidentifier), 'Black', 'Neil', 'nblack', 'nblack@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('f8ed7a26-d4b9-419f-9dd6-c8be4757adf2' AS uniqueidentifier), 'Johnson', 'Brian', 'bjohnson', 'bjohnson@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('1b09229a-62d1-4019-a4ea-d25c4a2cb511' AS uniqueidentifier), 'Chow', 'Ray', 'rchow', 'rchow@adatum.com')
INSERT INTO dbo.Employees (EmployeeId, LastName, FirstName, Alias, Email)
VALUES (CAST('3c597d78-6c31-4267-bfea-f49b4e915915' AS uniqueidentifier), 'Kurrmann', 'Benno', 'bkurrmann', 'bkurrmann@adatum.com')


INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('9ed9ec83-fd5e-47eb-95a7-025bd8bfe3c0' AS uniqueidentifier), CAST('a85006a6-8c60-4b22-a3b8-21cb11851305' AS uniqueidentifier), 'DirectX', 'This release requires Microsoft Visual C# 2005 Express to be installed before proceeding.  You can install Visual C# Express from the Visual C# Express Download Page. However, other members of the Visual Studio 2005 line of products, for example Visual Studio 2005 Professional, can co-exist with XNA Game Studio Express (pre-release) on the same computer.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('1646ff0c-bff0-466f-95c0-1fc529dbaf3e' AS uniqueidentifier), CAST('87e8e737-c56f-4e95-a8af-c0d6ae60532a' AS uniqueidentifier), 'Host Integration Server', 'Microsoft Host Integration Server provides comprehensive host access and integration, extending Microsoft Windows to other systems by integrating mission-critical host applications, data sources, messaging, and security systems. This enables the reuse of IBM mainframe and midrange data and applications across distributed environments.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('6a00cf87-50b9-4afc-89bf-26ec8e6bf2e2' AS uniqueidentifier), CAST('87e8e737-c56f-4e95-a8af-c0d6ae60532a' AS uniqueidentifier), 'Commerce Server', 'Microsoft® Commerce Server is a scalable e-commerce platform that provides ready-to-use features for developing, deploying, managing, and upgrading effective e-commerce applications for the Web. This extensible platform enables you to build solutions that scale with business needs and integrate with existing systems and data. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('67e791ed-acc5-411b-8d42-2988f7ef0020' AS uniqueidentifier), CAST('3c597d78-6c31-4267-bfea-f49b4e915915' AS uniqueidentifier), 'Exchange Server', 'Microsoft® Exchange Server is the messaging platform that provides e-mail, scheduling, and the tools for custom collaboration and messaging-service applications. Easily create and manage your business communications both in the office and on the road by using Exchange Server. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('4dbc9a33-d2db-4f38-8de4-2d40dcc77ad5' AS uniqueidentifier), CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier), 'ADO.NET 2.0', 'ADO.NET provides consistent access to data sources such as Microsoft SQL Server and XML, as well as to data sources exposed through OLE DB and ODBC. Learn more about the new and enhanced features available in ADO.NET 2.0.  
')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('7e6fadf0-846d-413a-aeb8-4d9d1ff41b18' AS uniqueidentifier), CAST('3e8e578c-6810-48bd-aadb-620edecf988c' AS uniqueidentifier), 'InfoPath', 'The VSTO 2005 SE pre-release product fully integrates the Office InfoPath 2007 form template into the Visual Studio 2005 development environment, so that you can now design the layout of InfoPath forms and write managed code business logic without leaving Visual Studio.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('266547a9-fece-45de-866f-4e59146df63a' AS uniqueidentifier), CAST('660cfa74-a041-4988-8540-267f0f1cc379' AS uniqueidentifier), 'BizTalk Server', 'Microsoft® BizTalk Server 2006 includes several business rules samples in its software development kit (SDK). This section provides detailed information about the functionality demonstrated by each business rules sample, instructions for building and running the sample, and the results you can expect.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('792e3a85-fdee-4468-9418-4ef823fdeca7' AS uniqueidentifier), CAST('94e4f274-0ea2-4c35-90a9-424006276b71' AS uniqueidentifier), 'Visual Studio', 'Visual Studio 2005 provides a range of tools that offer many benefits for individual developers and software development teams:
Be more productive and obtain faster results
Build dynamic Windows, Web, mobile, and Office-based solutions
Communicate and collaborate more effectively within your software teams
Ensure quality early and often throughout the development process ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('ce181dcf-071c-4699-b1d5-51106f5c493e' AS uniqueidentifier), CAST('4c3631f8-2b98-45d7-8333-c13919d8bfa6' AS uniqueidentifier), 'TimeSpan', 'TimeSpan Structure  
Represents a time interval. 
Namespace: System
Assembly: mscorlib (in mscorlib.dll)')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('6353f6de-f7ad-403d-addc-55f6dfe05f16' AS uniqueidentifier), CAST('f8ed7a26-d4b9-419f-9dd6-c8be4757adf2' AS uniqueidentifier), 'Business Intelligence BI', 'SQL Server 2005 furthers Microsoft leadership in the area of business intelligence (BI) through innovations in scalability, data integration, development tools, and rich analytics. SQL Server 2005 enables scalable BI by putting critical, timely information in the hands of employees across your organization. From the CEO to the information worker, employees will be able to quickly and easily harness data to make better decisions faster. The comprehensive integration, analysis, and reporting capabilities of SQL Server 2005 enable companies to extend the value of their existing applications, regardless of the underlying platform. BI features include enhancements in the following areas:
• An end-to-end integrated business intelligence platform 
• Integration Services
• Analysis Services 
• Reporting Services 
• Integration with the Microsoft Office System
')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('70f77e86-4d57-4764-a5f4-6348413a294c' AS uniqueidentifier), CAST('e8de2a50-9907-4147-89e7-7d643d677469' AS uniqueidentifier), 'System.Diagnostics', 'The System.Diagnostics namespace provides classes that allow you to interact with system processes, event logs, and performance counters. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('c48b9e3f-de94-4612-8285-7b0cca731bd3' AS uniqueidentifier), CAST('e8de2a50-9907-4147-89e7-7d643d677469' AS uniqueidentifier), 'Enterprise Data Management', 'SQL Server 2005 makes it simpler and easier to deploy, manage, and optimize enterprise data and analytical applications. As an enterprise data management platform, it provides a single management console that enables data administrators anywhere in your organization to monitor, manage, and tune all of the databases and associated services across your enterprise. It provides an extensible management infrastructure that can be easily programmed using SQL Management Objects, enabling users to customize and extend their management environment and independent software vendors (ISVs) to build additional tools and functionality to further extend the capabilities that come out of the box.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('fbbfae34-84fb-418c-8da6-7bfbc13daf17' AS uniqueidentifier), CAST('1b09229a-62d1-4019-a4ea-d25c4a2cb511' AS uniqueidentifier), 'Speech Application Software ', 'Developers can use the Microsoft Speech Application SDK (SASDK) Version 1.1 to quickly and easily add speech interfaces to Microsoft ASP.NET Web applications. The development tools included in the SASDK support the Speech Application Language Tags (SALT) specification.
')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('015f2713-e4c0-4ffd-845c-a6ab87e63f06' AS uniqueidentifier), CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier), 'ADO.NET', 'ADO.NET provides a rich set of components for creating distributed, data-sharing applications. It is an integral part of the .NET Framework, providing access to relational data, XML, and application data. ADO.NET supports a variety of development needs, including the creation of database clients and middle-tier business objects used by applications, tools, languages, or Internet browsers.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('e160d711-7972-4c3e-a709-ab103b6fa1bb' AS uniqueidentifier), CAST('3e8e578c-6810-48bd-aadb-620edecf988c' AS uniqueidentifier), 'Internet Security and Acceleration (ISA) Server', 'Microsoft Internet Security and Acceleration (ISA) Server is an extensible, multilayer enterprise firewall and Web cache that helps provide secure, fast, and manageable Internet connectivity. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('3b9c245d-a2df-4e2f-8c48-ac75deda7433' AS uniqueidentifier), CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier), 'SQL Architecture and Design', 'Designing a database requires an understanding of the business functions you want to model. It also requires an understanding of the database concepts and features that you want to use to represent those business functions. Make sure that you accurately design the database to model the business, because it can be time-consuming to significantly change the design of a database after you implement it. A well-designed database also performs better. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('6196b0b1-ee13-4a21-b1fd-b5aa26636fa2' AS uniqueidentifier), CAST('00fcefa4-bf81-4674-81c1-c2de86f0c5f6' AS uniqueidentifier), 'Korean Language Version of Visual Studio .NET', 'When you install the re-release of the Korean-language version of Visual Studio 2005 or of Visual Studio .NET from a network folder, the files for the currently installed Visual Studio 2005 or Visual Studio .NET program are not updated. ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('9da8c899-16f1-479f-893e-bb983f7e1bae' AS uniqueidentifier), CAST('660cfa74-a041-4988-8540-267f0f1cc379' AS uniqueidentifier), 'Windows Script', 'Windows Script is a comprehensive scripting infrastructure for the Microsoft® Windows® platform. Windows Script provides two script engines, Visual Basic® Scripting Edition and Microsoft JScript®, which can be embedded into Windows Applications. It also provides an extensive array of supporting technologies that makes it easier for script users to script Windows applications.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('6c37f6b2-6865-423e-ac0d-d397dbe07898' AS uniqueidentifier), CAST('1a20fc12-6ca1-46d2-b9dc-c5c42be8a2b1' AS uniqueidentifier), 'ADO.NET 2.0', 'ADO.NET provides consistent access to data sources such as Microsoft SQL Server and XML, as well as to data sources exposed through OLE DB and ODBC. Learn more about the new and enhanced features available in ADO.NET 2.0.  ')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('52ee6567-b2fa-4426-b227-e4d721fe7e8c' AS uniqueidentifier), CAST('24459614-fa32-4d2c-a133-363ba736643c' AS uniqueidentifier), 'MDAC', 'This portion of the MSDN Data Access and Storage Developer Center hosts information on Microsofts native-code data access technologies: ADO, OLEDB, ODBC, and others. Look to this site to get the latest MDAC release and all supported releases, as well as documentation, code samples, support resources, and community.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('e055da34-dc2c-4060-97fd-f4f966e2b185' AS uniqueidentifier), CAST('0c24972a-9746-4d3f-aaab-8c9fb7706525' AS uniqueidentifier), 'IIS', 'ASP.NET IIS Registration Tool (Aspnet_regiis.exe)  
When multiple versions of the .NET Framework are executing side-by-side on a single computer, the ASP.NET ISAPI version mapped to an ASP.NET application determines which version of the common language runtime (CLR) is used for the application. The ASP.NET IIS Registration Tool (Aspnet_regiis.exe) allows an administrator or installation program to easily update the script maps for an ASP.NET application to point to the ASP.NET ISAPI version that is associated with the tool. The tool can also be used to display the status of all installed versions of ASP. NET, register the ASP.NET version that is coupled with the tool, create client-script directories, and perform other configuration operations.')
INSERT INTO dbo.Skills (SkillId, EmployeeId, SkillName, BriefDescription)
VALUES (CAST('b9ec6b2f-0d66-48cf-a6bc-f8151af3a5c5' AS uniqueidentifier), CAST('1b09229a-62d1-4019-a4ea-d25c4a2cb511' AS uniqueidentifier), 'Speech Server', 'MSS 2004 R2 is Microsofts tool for deploying and managing distributed speech applications that combine Web technologies, speech-processing services, and telephony capabilities in a single, integrated, flexible, cost-effective platform. ')


INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('127812a0-37d5-4943-819a-07f999fe9e22' AS uniqueidentifier), 'http://msdn.microsoft.com/vstudio/express/sql/powerful/', CAST('e160d711-7972-4c3e-a709-ab103b6fa1bb' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('9453f40f-eb0b-4bed-85c1-0a01b1272c55' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnanchor/html/netspeechanchor.asp', CAST('b9ec6b2f-0d66-48cf-a6bc-f8151af3a5c5' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('25dc27fa-be2d-4d3e-9047-0d39ff3543aa' AS uniqueidentifier), 'http://msdn.microsoft.com/office/program/infopath/', CAST('7e6fadf0-846d-413a-aeb8-4d9d1ff41b18' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('946848c5-f148-46cb-9890-134f0e83720e' AS uniqueidentifier), 'http://msdn.microsoft.com/vstudio/', CAST('792e3a85-fdee-4468-9418-4ef823fdeca7' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('d8479fb5-53ff-4be7-be56-18c35d13be0d' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnanchor/html/scriptinga.asp', CAST('9da8c899-16f1-479f-893e-bb983f7e1bae' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('1922d569-e8fa-4611-a5f8-27a90f9ad98e' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemdiagnostics.asp', CAST('70f77e86-4d57-4764-a5f4-6348413a294c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('f7448fcf-1ed6-4617-8d24-28f2cdbcf07e' AS uniqueidentifier), 'http://msdn.microsoft.com/vstudio/express/visualcsharp/default.aspx', CAST('9ed9ec83-fd5e-47eb-95a7-025bd8bfe3c0' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('0b65db38-f87f-4b5f-91c8-387fa5e34a9c' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnanchor/html/netdevanchor.asp', CAST('70f77e86-4d57-4764-a5f4-6348413a294c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('4a190439-d6e8-4457-86c6-38a9826d7fb2' AS uniqueidentifier), 'http://msdn.microsoft.com/directx/xna/gse/', CAST('9ed9ec83-fd5e-47eb-95a7-025bd8bfe3c0' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('142742af-1dfd-4c72-b891-3ab330cea9b1' AS uniqueidentifier), 'http://msdn.microsoft.com/vstudio/learning/default.aspx', CAST('792e3a85-fdee-4468-9418-4ef823fdeca7' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('f63f4737-52e2-4449-a5ac-42ee7e852b7d' AS uniqueidentifier), 'http://www.microsoft.com/downloads/details.aspx?FamilyID=ef62d47d-ce5a-44fa-864f-3c31c14769b7&DisplayLang=en', CAST('fbbfae34-84fb-418c-8da6-7bfbc13daf17' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('a9c1e20f-4342-4c8e-a1d1-591fa42e4ac0' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/BTS06CoreDocs/html/d5c19d43-6688-4138-88b1-6e933ccbd14b.asp', CAST('266547a9-fece-45de-866f-4e59146df63a' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('b213430c-2ce0-43d7-ade3-6311cb9376ae' AS uniqueidentifier), 'http://msdn.microsoft.com/data/ref/default.aspx', CAST('6c37f6b2-6865-423e-ac0d-d397dbe07898' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('aa41c1d8-52f0-47c4-abd8-638a4759e1a8' AS uniqueidentifier), 'http://msdn.microsoft.com/vstudio/reference/default.aspx', CAST('67e791ed-acc5-411b-8d42-2988f7ef0020' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('c2251c59-a775-42de-8c37-645dd5c6565a' AS uniqueidentifier), 'http://msdn.microsoft.com/data/ref/mdac/default.aspx', CAST('52ee6567-b2fa-4426-b227-e4d721fe7e8c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('f864dbc2-9522-4f79-928c-7b73f19272b3' AS uniqueidentifier), 'http://msdn.microsoft.com/data/ref/mdac/default.aspx?pull=/library/en-us/dnmdac/html/data_mdacroadmap.asp', CAST('52ee6567-b2fa-4426-b227-e4d721fe7e8c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('608367dd-2bf5-4ea1-ab98-7ff179a41602' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadonet/html/adonetbest.asp', CAST('015f2713-e4c0-4ffd-845c-a6ab87e63f06' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('4263d085-c8d1-4ca2-9eca-85271564b930' AS uniqueidentifier), 'http://www.microsoft.com/downloads/details.aspx?FamilyID=1194ed95-7a23-46a0-bbbc-06ef009c053a&DisplayLang=en', CAST('fbbfae34-84fb-418c-8da6-7bfbc13daf17' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('685b13df-80ee-40d2-bb10-862ef7a43545' AS uniqueidentifier), 'http://msdn2.microsoft.com/en-us/netframework/default.aspx', CAST('1646ff0c-bff0-466f-95c0-1fc529dbaf3e' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('c2a56a16-96b4-430f-bac7-867945a0ca77' AS uniqueidentifier), 'http://msdn.microsoft.com/data/ref/default.aspx', CAST('4dbc9a33-d2db-4f38-8de4-2d40dcc77ad5' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('dc5f10f6-f1f8-4dfa-ac32-963f10f585bb' AS uniqueidentifier), 'http://support.microsoft.com/kb/324901', CAST('6196b0b1-ee13-4a21-b1fd-b5aa26636fa2' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('da3d9ff3-7915-4357-9241-9c5f16d41565' AS uniqueidentifier), 'http://msdn.microsoft.com/sql/learning/arch/default.aspx', CAST('3b9c245d-a2df-4e2f-8c48-ac75deda7433' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('f6033447-73f1-44ee-8776-a26b4d8f8ded' AS uniqueidentifier), 'http://www.microsoft.com/sql/prodinfo/overview/whats-new-in-sqlserver2005.mspx#EBEAC', CAST('6353f6de-f7ad-403d-addc-55f6dfe05f16' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('9313db12-1bda-4d71-a55e-dcb31898c57b' AS uniqueidentifier), 'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnanchor/html/adonetanchor.asp', CAST('015f2713-e4c0-4ffd-845c-a6ab87e63f06' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('5bb04d87-21fc-49c1-8995-ddb80a7424ed' AS uniqueidentifier), 'http://msdn.microsoft.com/data/ref/default.aspx', CAST('6a00cf87-50b9-4afc-89bf-26ec8e6bf2e2' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('2ae3807e-cdf5-43de-acac-de9d99492ea5' AS uniqueidentifier), 'http://msdn2.microsoft.com/en-us/library/k6h9cz8h(VS.80).aspx', CAST('e055da34-dc2c-4060-97fd-f4f966e2b185' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('74de84c0-68cb-4095-b68d-e97090a0f849' AS uniqueidentifier), 'http://msdn2.microsoft.com/en-us/library/system.timespan.aspx', CAST('ce181dcf-071c-4699-b1d5-51106f5c493e' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('32616160-18f1-4a9f-9846-f63578896d21' AS uniqueidentifier), 'http://msdn.microsoft.com/data/', CAST('70f77e86-4d57-4764-a5f4-6348413a294c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('e058cd8e-ccb4-496c-a486-f7417f81f716' AS uniqueidentifier), 'http://www.microsoft.com/downloads/details.aspx?familyid=5067faf8-0db4-429a-b502-de4329c8c850&displaylang=en', CAST('52ee6567-b2fa-4426-b227-e4d721fe7e8c' AS uniqueidentifier))
INSERT INTO dbo.SkillInfo(SkillInfoId, URL, SkillId)
VALUES (CAST('178059c5-fa63-4255-97ef-f7902c661391' AS uniqueidentifier), 'http://www.microsoft.com/sql/prodinfo/overview/whats-new-in-sqlserver2005.mspx#EZ', CAST('c48b9e3f-de94-4612-8285-7b0cca731bd3' AS uniqueidentifier))


INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('f1dcb279-df14-4398-bac5-08f21ea4c1ec' AS uniqueidentifier), 'Black', 'Neil', 'PM', 'nblack', 'nblack@adatum.com', CAST('4c3631f8-2b98-45d7-8333-c13919d8bfa6' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('18f14c03-7f3a-4789-adcb-10df917f4f48' AS uniqueidentifier), 'Chow', 'Ray', 'SQL Server', 'rchow@adatum.com', 'rchow@adatum.com', CAST('1a20fc12-6ca1-46d2-b9dc-c5c42be8a2b1' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('68c39623-3b74-424e-9634-202de7ea79df' AS uniqueidentifier), 'Aaberg', 'Jesper', 'Architect', 'jaberg@adatum.com', 'jaberg@adatum.com', CAST('94e4f274-0ea2-4c35-90a9-424006276b71' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('ee082f9f-d528-4003-880f-260b2d8e56ab' AS uniqueidentifier), 'Haas', 'Jonathan', 'PM', 'jhaas@adatum.com', 'jhaas@adatum.com', CAST('87e8e737-c56f-4e95-a8af-c0d6ae60532a' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('e0fe21f3-07f3-412f-ad73-2f69c4acd751' AS uniqueidentifier), 'Magnotta', 'Maureen', 'IIS Admin', 'mmagnotta', 'mmagnotta@adatum.com', CAST('0c24972a-9746-4d3f-aaab-8c9fb7706525' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('bc64a8be-9021-425e-a12a-409b12adcbec' AS uniqueidentifier), 'Kurrmann', 'Benno', 'PM', 'bkurrmann', 'bkurrmann@adatum.com', CAST('e8de2a50-9907-4147-89e7-7d643d677469' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('45b91172-6fe1-4edf-8ec6-5c67f04b29c3' AS uniqueidentifier), 'Paiha', 'Domi', 'Developer', 'dpaiha', 'dpaiha@adatum.com', CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('77e562c5-59f8-43fe-952d-6ee7b408dea4' AS uniqueidentifier), 'Haas', 'Jonathan', 'Developer', 'jhaas', 'jhaas@adatum.com', CAST('3e8e578c-6810-48bd-aadb-620edecf988c' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('e191322d-c19b-4db5-9ef8-845b55c8c0c9' AS uniqueidentifier), 'Bossard', 'David', 'PM', 'dbossard', 'dbossard@adatum.com', CAST('1b09229a-62d1-4019-a4ea-d25c4a2cb511' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('47c1e487-5a58-48fb-8be4-97cfbe349cb8' AS uniqueidentifier), 'Aaberg', 'Jesper', 'Developer', 'dbossard', 'dbossard@adatum.com', CAST('660cfa74-a041-4988-8540-267f0f1cc379' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('033c555b-9d4d-49e7-8138-97d9d19f0ed5' AS uniqueidentifier), 'Paiha', 'Domi ', 'Developer', 'dpaiha', 'dpaiha@adatum.com', CAST('84ff3e6a-f4d2-4753-ab23-2baf1a6b3f45' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('5892adea-62f9-465e-abd6-d4e30b72a071' AS uniqueidentifier), 'Dickson', 'Holly', 'Dev Lead', 'hdickson', 'hdickson@adatum.com', CAST('24459614-fa32-4d2c-a133-363ba736643c' AS uniqueidentifier))
INSERT INTO dbo.[References](ReferenceId, LastName, FirstName, Position, Alias, Email, EmployeeId)
VALUES (CAST('88ef8291-3145-40c5-9387-ebbccd508ce1' AS uniqueidentifier), 'Johnson', 'Brian', 'PM', 'bjohnson', 'bjohnson@adatum.com', CAST('3c597d78-6c31-4267-bfea-f49b4e915915' AS uniqueidentifier))
