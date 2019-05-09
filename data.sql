USE [BeanStore]
GO
SET IDENTITY_INSERT [dbo].[catalogs] ON 

INSERT [dbo].[catalogs] ([id], [name]) VALUES (1, N'Smartphone')
INSERT [dbo].[catalogs] ([id], [name]) VALUES (2, N'Tablet')
INSERT [dbo].[catalogs] ([id], [name]) VALUES (3, N'Gear')
SET IDENTITY_INSERT [dbo].[catalogs] OFF
SET IDENTITY_INSERT [dbo].[brand] ON 

INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (1, N'Apple', N'banner01.png                                                                                        ', N'iPhone-(Apple)42-b_16.jpg                                                                           ', 1)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (2, N'Samsung', N'banner02.png                                                                                        ', N'Samsung42-b_25.jpg                                                                                  ', 0)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (3, N'Nokia', N'banner03.png                                                                                        ', N'Nokia42-b_21.jpg                                                                                    ', 0)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (4, N'Huawei', N'banner04.png                                                                                        ', N'Huawei42-b_22.png                                                                                   ', 1)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (5, N'Xiaomi', N'banner05.png                                                                                        ', N'Xiaomi42-b_31.png                                                                                   ', 1)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (6, N'Sony', NULL, NULL, 0)
INSERT [dbo].[brand] ([id], [name], [banner_link], [logo], [showinbanner]) VALUES (7, N'Other', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[brand] OFF
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (1, 2, 1, N'Samsung Galaxy Note 9', 1100, 100, CAST(N'2020-10-27 00:00:00.000' AS DateTime), 9, N'galaxy-note-9.jpg', N'note9-_5__1.jpg', N'dsc03177-153388769796190219015_1.jpg', N'galaxy-note-9-black-back_2.png', N'galaxy-note-9-purple-back_2.png')
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (2, 2, 1, N'Samsung Galaxy S10', 890, 120, CAST(N'2019-10-25 00:00:00.000' AS DateTime), 0, N'sieu-pham-galaxy-s-black-400x400_1.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (3, 2, 1, N'Samsung Galaxy M20', 220, 300, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 25, N'samsung-galaxy-m20-m205f-1_1_2.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (4, 1, 1, N'Apple iPhone XS 64GB', 1150, 150, CAST(N'2020-10-23 00:00:00.000' AS DateTime), 5, N'xs-max-gold-sgmall-2sim-2_3.jpg', N'xs-back_8_3.png', N'xs-1_9_5_3.png', N'xs_8_3.png', NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (5, 1, 1, N'Apple iPhone 7 Plus 32GB', 550, 300, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 0, N'iphone-7-plus-pink_3_3_1_1.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (6, 1, 1, N'Apple iPhone 8 64GB', 860, 200, CAST(N'2019-10-24 00:00:00.000' AS DateTime), 10, N'8-gray_2_5.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (7, 3, 1, N'Nokia 9', 530, 0, CAST(N'2020-10-26 00:00:00.000' AS DateTime), 7, N'9_1_111.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (8, 3, 1, N'Nokia 8.1', 120, 360, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 7, N'nokia-8-1-featured.png', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (9, 3, 1, N'Nokia 5.1 Plus 32GB', 200, 180, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 7, N'1512844-01.jpg', N'hmd_panda_white_ari_lowres_row1_27062018_1_1.png', N'hmd_panda_packshot_lowres_row1_27062018.png', NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (10, 5, 1, N'Xiaomi Mi Mix 3', 550, 80, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 10, N'xiaomi-mi-mix-3-render-based-on-leaks-1-1600x1234_1_1.jpg', N'xiaomi-mi-mix-3-xanh-l_c-b_o.png', NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (11, 5, 1, N'Xiaomi Pocophone F1', 380, 100, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 15, N'poco-f1-black_2.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (12, 5, 1, N'Xiaomi Mi 9', 550, 200, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 15, N'xiaomi-mi-9_2-1.jpg', N'xiaomi-mi-9-2.jpg', N'13d2a6a0bf0091253dbafdd6aa3a3efa_xl.jpg', N'xiaomi-mi-9-6-39-inch-8gb-128gb-smartphone-gray-831513-.jpg', NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (13, 4, 1, N'Huawei Mate X', 2000, 0, CAST(N'2020-10-25 00:00:00.000' AS DateTime), 5, N'huawei-mate-x-foldable-smartphone-grey_dezeen_2364_col_6-852x862.jpg', N'huawei-mate-x-hands-on-mwc-2019-17.jpg', N'huawei-mate-x-2-600x600.jpg', NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (14, 4, 1, N'Huawei P30 Pro', 750, 200, CAST(N'2019-10-26 00:00:00.000' AS DateTime), 8, N'skyblue-rgb-500x500.png', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (15, 4, 1, N'Huawei nova 3i', 280, 300, CAST(N'2019-10-25 00:00:00.000' AS DateTime), 5, N'huawei-nova-3i-trang-chipu-600x600.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (18, 1, 2, N'iPad Pro 11 inch (2018)

', 1200, 50, CAST(N'2020-10-25 00:00:00.000' AS DateTime), 0, N'may-tinh-bang-ipad-pro-11-inch-256gb-wifi-2018-33397-chitiet-400x460.png', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (19, 2, 2, N'Samsung Galaxy Tab A', 460, 30, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 20, N'samsung-galaxy-tab-a-105-inch-chitietblue-400x460.png', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (20, 4, 2, N'Huawei Mediapad T5', 250, 40, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 15, N'huawei-mediapad-t5-33397-hinhchitiet-400x460.png', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (21, 7, 3, N'Micro USB 0.2 m eSaver', 2, 800, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 10, N'cap-micro-usb-20cm-esaver-ds026-avatar-1-600x600.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (22, 7, 3, N'10.000 mAh Type C eSaver', 15, 300, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 8, N'polymer-10000-mah-type-c-esaver-pj-jp106s-avatar-1-600x600.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([id], [brand_id], [catalog_id], [name], [price], [discount], [created], [sale], [image_link], [image_link2], [image_link3], [image_link4], [image_link5]) VALUES (24, 7, 3, N'Kanen IP-2090', 8, 400, CAST(N'2019-10-27 00:00:00.000' AS DateTime), 12, N'tai-nghe-chup-tai-kanen-ip-2090-2-3-600x600.jpg', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[items] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [name], [phone], [email], [address], [password]) VALUES (1, N'Mr Tran', N'0969969969', N'mr.tran@gmail.com', N'182 bach dang', N'1')
INSERT [dbo].[user] ([id], [name], [phone], [email], [address], [password]) VALUES (4, N'Mr Nguyen', N'0123456789', N'mr.nguyen@gmail.com', NULL, N'2')
INSERT [dbo].[user] ([id], [name], [phone], [email], [address], [password]) VALUES (5, N'Mr Pham', N'0900900099', N'mr.pham@gmail.com', NULL, N'3')
SET IDENTITY_INSERT [dbo].[user] OFF
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([id], [user_id], [status], [order_date], [delivery_date], [total_price]) VALUES (9, 1, 0, NULL, NULL, NULL)
INSERT [dbo].[order] ([id], [user_id], [status], [order_date], [delivery_date], [total_price]) VALUES (10, 1, 0, NULL, NULL, NULL)
INSERT [dbo].[order] ([id], [user_id], [status], [order_date], [delivery_date], [total_price]) VALUES (11, 4, 0, NULL, NULL, NULL)
INSERT [dbo].[order] ([id], [user_id], [status], [order_date], [delivery_date], [total_price]) VALUES (12, 1, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[order] OFF
SET IDENTITY_INSERT [dbo].[det_order] ON 

INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (1, 10, 24, 1, CAST(8 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (2, 10, 22, 1, CAST(15 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (3, 10, 21, 1, CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (4, 11, 4, 1, CAST(1150 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (5, 11, 7, 1, CAST(530 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (6, 11, 13, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (7, 12, 24, 1, CAST(8 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (8, 12, 22, 6, CAST(90 AS Decimal(18, 0)))
INSERT [dbo].[det_order] ([id], [order_id], [item_id], [quantity], [amount]) VALUES (9, 12, 21, 1, CAST(2 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[det_order] OFF
SET IDENTITY_INSERT [dbo].[admin] ON 

INSERT [dbo].[admin] ([id], [name], [username], [password]) VALUES (1, N'Trần Hội', N'tranhoi', N'11111111')
INSERT [dbo].[admin] ([id], [name], [username], [password]) VALUES (3, N'Mỹ Ngọc', N'myngoc', N'22222222')
INSERT [dbo].[admin] ([id], [name], [username], [password]) VALUES (5, N'Ngọc Thắng', N'ngocthang', N'33333333')
SET IDENTITY_INSERT [dbo].[admin] OFF
