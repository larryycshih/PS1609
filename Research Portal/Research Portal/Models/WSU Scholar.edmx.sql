
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/22/2016 16:35:55
-- Generated from EDMX file: L:\PS1609\Research Portal\Research Portal\Models\WSU Scholar.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Record__research__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Record] DROP CONSTRAINT [FK__Record__research__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK_Author_School]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Author] DROP CONSTRAINT [FK_Author_School];
GO
IF OBJECT_ID(N'[dbo].[FK_Research_School]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Research] DROP CONSTRAINT [FK_Research_School];
GO
IF OBJECT_ID(N'[Database1ModelStoreContainer].[FK_ResearchAuthor_Author]', 'F') IS NOT NULL
    ALTER TABLE [Database1ModelStoreContainer].[ResearchAuthor] DROP CONSTRAINT [FK_ResearchAuthor_Author];
GO
IF OBJECT_ID(N'[Database1ModelStoreContainer].[FK_ResearchAuthor_Research]', 'F') IS NOT NULL
    ALTER TABLE [Database1ModelStoreContainer].[ResearchAuthor] DROP CONSTRAINT [FK_ResearchAuthor_Research];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Author]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Author];
GO
IF OBJECT_ID(N'[dbo].[Record]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Record];
GO
IF OBJECT_ID(N'[dbo].[Research]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Research];
GO
IF OBJECT_ID(N'[dbo].[School]', 'U') IS NOT NULL
    DROP TABLE [dbo].[School];
GO
IF OBJECT_ID(N'[Database1ModelStoreContainer].[ResearchAuthor]', 'U') IS NOT NULL
    DROP TABLE [Database1ModelStoreContainer].[ResearchAuthor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [authorID] int  NOT NULL,
    [title] nchar(10)  NULL,
    [fname] nvarchar(50)  NULL,
    [lname] nvarchar(50)  NULL,
    [schoolID] int  NULL,
    [telephone] int  NULL,
    [email] nvarchar(50)  NULL,
    [mobile] int  NULL,
    [university] nvarchar(50)  NULL,
    [campus] nvarchar(50)  NULL,
    [School_schoolID] int  NOT NULL
);
GO

-- Creating table 'Records'
CREATE TABLE [dbo].[Records] (
    [recordID] int  NOT NULL,
    [researchID] int  NOT NULL,
    [fileID] nchar(10)  NULL,
    [Research_researchID] int  NOT NULL
);
GO

-- Creating table 'Researches'
CREATE TABLE [dbo].[Researches] (
    [researchID] int  NOT NULL,
    [title] nchar(10)  NULL,
    [schoolID] int  NULL,
    [publishedDate] datetime  NULL,
    [subject] nvarchar(50)  NULL,
    [grants] float  NULL,
    [views] int  NULL,
    [downloads] int  NULL,
    [abstract] nvarchar(max)  NULL,
    [School_schoolID] int  NOT NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [schoolID] int  NOT NULL,
    [schoolName] nvarchar(50)  NULL,
    [disciplineName] nvarchar(50)  NULL
);
GO

-- Creating table 'ResearchAuthors'
CREATE TABLE [dbo].[ResearchAuthors] (
    [researchID] int  NOT NULL,
    [authorID] int  NOT NULL,
    [Author_authorID] int  NOT NULL,
    [Research_researchID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [authorID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([authorID] ASC);
GO

-- Creating primary key on [recordID] in table 'Records'
ALTER TABLE [dbo].[Records]
ADD CONSTRAINT [PK_Records]
    PRIMARY KEY CLUSTERED ([recordID] ASC);
GO

-- Creating primary key on [researchID] in table 'Researches'
ALTER TABLE [dbo].[Researches]
ADD CONSTRAINT [PK_Researches]
    PRIMARY KEY CLUSTERED ([researchID] ASC);
GO

-- Creating primary key on [schoolID] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([schoolID] ASC);
GO

-- Creating primary key on [researchID], [authorID] in table 'ResearchAuthors'
ALTER TABLE [dbo].[ResearchAuthors]
ADD CONSTRAINT [PK_ResearchAuthors]
    PRIMARY KEY CLUSTERED ([researchID], [authorID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Author_authorID] in table 'ResearchAuthors'
ALTER TABLE [dbo].[ResearchAuthors]
ADD CONSTRAINT [FK_AuthorResearchAuthor]
    FOREIGN KEY ([Author_authorID])
    REFERENCES [dbo].[Authors]
        ([authorID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorResearchAuthor'
CREATE INDEX [IX_FK_AuthorResearchAuthor]
ON [dbo].[ResearchAuthors]
    ([Author_authorID]);
GO

-- Creating foreign key on [Research_researchID] in table 'Records'
ALTER TABLE [dbo].[Records]
ADD CONSTRAINT [FK_ResearchRecord]
    FOREIGN KEY ([Research_researchID])
    REFERENCES [dbo].[Researches]
        ([researchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResearchRecord'
CREATE INDEX [IX_FK_ResearchRecord]
ON [dbo].[Records]
    ([Research_researchID]);
GO

-- Creating foreign key on [Research_researchID] in table 'ResearchAuthors'
ALTER TABLE [dbo].[ResearchAuthors]
ADD CONSTRAINT [FK_ResearchResearchAuthor]
    FOREIGN KEY ([Research_researchID])
    REFERENCES [dbo].[Researches]
        ([researchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResearchResearchAuthor'
CREATE INDEX [IX_FK_ResearchResearchAuthor]
ON [dbo].[ResearchAuthors]
    ([Research_researchID]);
GO

-- Creating foreign key on [School_schoolID] in table 'Researches'
ALTER TABLE [dbo].[Researches]
ADD CONSTRAINT [FK_SchoolResearch]
    FOREIGN KEY ([School_schoolID])
    REFERENCES [dbo].[Schools]
        ([schoolID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolResearch'
CREATE INDEX [IX_FK_SchoolResearch]
ON [dbo].[Researches]
    ([School_schoolID]);
GO

-- Creating foreign key on [School_schoolID] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [FK_SchoolAuthor]
    FOREIGN KEY ([School_schoolID])
    REFERENCES [dbo].[Schools]
        ([schoolID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SchoolAuthor'
CREATE INDEX [IX_FK_SchoolAuthor]
ON [dbo].[Authors]
    ([School_schoolID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------