GO
ALTER DATABASE [BeanStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BeanStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BeanStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BeanStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BeanStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BeanStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BeanStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BeanStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BeanStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BeanStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BeanStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BeanStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BeanStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BeanStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BeanStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BeanStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BeanStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BeanStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BeanStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BeanStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BeanStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BeanStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BeanStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BeanStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BeanStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BeanStore] SET  MULTI_USER 
GO
ALTER DATABASE [BeanStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BeanStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BeanStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BeanStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BeanStore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BeanStore]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position_id] [int] NULL,
	[name] [nvarchar](50) NULL CONSTRAINT [DF_admin_name]  DEFAULT (NULL),
	[username] [varchar](16) NOT NULL,
	[password] [varchar](8) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[banner]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[banner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[banner_link] [varchar](100) NULL,
 CONSTRAINT [PK_banner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[brand]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[logo] [char](100) NULL,
 CONSTRAINT [PK_sports] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[catalogs]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_catalogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[det_order]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[det_order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK_det_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[items]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand_id] [int] NOT NULL,
	[catalog_id] [int] NOT NULL,
	[ranked_id] [int] NULL,
	[name] [nvarchar](100) NULL,
	[price] [int] NULL,
	[discount] [int] NULL,
	[created] [datetime] NULL,
	[sale] [int] NULL,
	[description] [varchar](2000) NULL,
	[image_link] [varchar](100) NULL,
	[image_link2] [varchar](100) NULL,
	[image_link3] [varchar](100) NULL,
	[image_link4] [varchar](100) NULL,
	[image_link5] [varchar](100) NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[messeage]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[messeage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[message] [varchar](1000) NULL,
 CONSTRAINT [PK_Messeage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[order]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[status_id] [int] NULL,
	[order_date] [datetime] NULL,
	[delivery_date] [datetime] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[position]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ranked]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ranked](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NULL,
 CONSTRAINT [PK_ranked] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[status]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 7/3/2019 11:35:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phone] [varchar](15) NULL,
	[email] [varchar](128) NOT NULL,
	[address] [nvarchar](256) NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_position] FOREIGN KEY([position_id])
REFERENCES [dbo].[position] ([id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_position]
GO
ALTER TABLE [dbo].[det_order]  WITH CHECK ADD  CONSTRAINT [FK_det_order_items] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([id])
GO
ALTER TABLE [dbo].[det_order] CHECK CONSTRAINT [FK_det_order_items]
GO
ALTER TABLE [dbo].[det_order]  WITH CHECK ADD  CONSTRAINT [FK_det_order_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[det_order] CHECK CONSTRAINT [FK_det_order_order]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_brand] FOREIGN KEY([brand_id])
REFERENCES [dbo].[brand] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_brand]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_catalogs] FOREIGN KEY([catalog_id])
REFERENCES [dbo].[catalogs] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_catalogs]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_items_ranked] FOREIGN KEY([ranked_id])
REFERENCES [dbo].[ranked] ([id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_items_ranked]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_status]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_users]
GO
USE [master]
GO
ALTER DATABASE [BeanStore] SET  READ_WRITE 
GO
