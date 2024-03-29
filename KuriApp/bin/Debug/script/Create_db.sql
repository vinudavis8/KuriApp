
USE [master]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'kuriapp')
BEGIN
ALTER DATABASE kuriapp SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE kuriapp
END
GO
USE [master]
GO
/****** Creating Database [ExpenseManager]  ******/
CREATE DATABASE [kuriapp]
GO
USE [kuriapp]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[agents](
	[agent_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NULL,
	[phone] [varchar](20) NULL,
	[address] [nvarchar](150) NULL,
	[area_id] [int] NULL,
 CONSTRAINT [PK_agents] PRIMARY KEY CLUSTERED 
(
	[agent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[area]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[area_id] [int] IDENTITY(1,1) NOT NULL,
	[area_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[division]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[division](
	[division_id] [int] IDENTITY(1,1) NOT NULL,
	[division_name] [nvarchar](50) NULL,
	[area_id] [int] NULL,
 CONSTRAINT [PK_division] PRIMARY KEY CLUSTERED 
(
	[division_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kuri_auction_history]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kuri_auction_history](
	[auction_id] [bigint] IDENTITY(1,1) NOT NULL,
	[kuri_id] [int] NULL,
	[auction_user_id] [int] NULL,
	[auction_amount] [decimal](18, 0) NULL,
	[auction_date] [datetime] NULL,
	[auction_amount_payment_date] [datetime] NULL,
	[new_term_amount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_kuri_acution_history] PRIMARY KEY CLUSTERED 
(
	[auction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kuri_master]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kuri_master](
	[kuri_id] [int] IDENTITY(1,1) NOT NULL,
	[division_id] [int] NULL,
	[kuri_name] [nvarchar](20) NULL,
	[kuri_amount] [decimal](18, 0) NULL,
	[terms] [int] NULL,
	[start_date] [date] NULL,
	[term_amount] [decimal](18, 0) NULL,
 CONSTRAINT [PK_kuri_master] PRIMARY KEY CLUSTERED 
(
	[kuri_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kuri_payment_schedule]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kuri_payment_schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kuri_id] [int] NULL,
	[payment_due_date] [datetime] NULL,
	[amount_tobe_paid] [decimal](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kuri_payments]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kuri_payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[division_id] [int] NULL,
	[kuri_id] [int] NULL,
	[user_id] [int] NULL,
	[agent_id] [int] NULL,
	[received_amount] [decimal](18, 0) NULL,
	[received_date] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kuri_users]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kuri_users](
	[kuri_id] [int] NULL,
	[user_id] [int] NULL,
	[kuri_user_name] [nvarchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 19-01-2021 07:53:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](15) NULL,
	[dob] [date] NULL,
	[membership_no] [nvarchar](15) NULL,
	[residential_address] [nvarchar](200) NULL,
	[shop_address] [nvarchar](200) NULL,
	[division_id] [int] NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'

GO

/****** Object:  View [dbo].[View_aution_history]    Script Date: 19-01-2021 07:54:35 AM ******/
DROP VIEW [dbo].[View_aution_history]
GO

/****** Object:  View [dbo].[View_aution_history]    Script Date: 19-01-2021 07:54:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_aution_history]
AS
SELECT dbo.kuri_master.kuri_id, dbo.division.division_id, dbo.division.division_name, dbo.kuri_master.kuri_name, dbo.users.name, dbo.users.user_id, dbo.kuri_auction_history.auction_amount, FORMAT(dbo.kuri_auction_history.auction_date, 'dd/MM/yyyy ') AS Expr1, 
             FORMAT(dbo.kuri_auction_history.auction_amount_payment_date, 'dd/MM/yyyy ') AS Expr2
FROM   dbo.division INNER JOIN
             dbo.kuri_master ON dbo.division.division_id = dbo.kuri_master.division_id INNER JOIN
             dbo.users ON dbo.division.division_id = dbo.users.division_id CROSS JOIN
             dbo.kuri_auction_history

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "division"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 179
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "kuri_auction_history"
            Begin Extent = 
               Top = 9
               Left = 336
               Bottom = 206
               Right = 686
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "kuri_master"
            Begin Extent = 
               Top = 9
               Left = 743
               Bottom = 206
               Right = 965
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "users"
            Begin Extent = 
               Top = 180
               Left = 57
               Bottom = 377
               Right = 310
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_aution_history'
GO





EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'

GO

/****** Object:  View [dbo].[View_Kuri_division_user]    Script Date: 19-01-2021 07:55:27 AM ******/
DROP VIEW [dbo].[View_Kuri_division_user]
GO

/****** Object:  View [dbo].[View_Kuri_division_user]    Script Date: 19-01-2021 07:55:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Kuri_division_user]
AS
SELECT dbo.division.division_name, dbo.kuri_master.kuri_name, dbo.kuri_payments.received_amount, FORMAT(dbo.kuri_payments.received_date, 'dd/MM/yyyy ') AS Expr1, dbo.users.name, dbo.users.user_id, dbo.kuri_payments.kuri_id
FROM   dbo.kuri_payments INNER JOIN
             dbo.kuri_master ON dbo.kuri_payments.kuri_id = dbo.kuri_master.kuri_id INNER JOIN
             dbo.division ON dbo.kuri_payments.division_id = dbo.division.division_id INNER JOIN
             dbo.users ON dbo.kuri_payments.user_id = dbo.users.user_id

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[10] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "kuri_payments"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 295
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "kuri_master"
            Begin Extent = 
               Top = 9
               Left = 633
               Bottom = 206
               Right = 855
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "division"
            Begin Extent = 
               Top = 180
               Left = 352
               Bottom = 350
               Right = 574
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "users"
            Begin Extent = 
               Top = 207
               Left = 57
               Bottom = 404
               Right = 310
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1650
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Kuri_division_user'
GO


