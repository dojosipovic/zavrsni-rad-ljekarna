USE [BAZA_LJEKARNA]
GO
/****** Object:  Table [dbo].[Artikl]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artikl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nchar](45) NOT NULL,
	[Cijena] [float] NOT NULL,
	[Kolicina] [int] NOT NULL,
	[JedinicaMjereID] [nchar](3) NOT NULL,
 CONSTRAINT [PK_Artikl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Artikl_Naziv] UNIQUE NONCLUSTERED 
(
	[Naziv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dobavljac]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dobavljac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OIB] [nchar](9) NOT NULL,
	[Naziv] [nchar](45) NOT NULL,
	[IBAN] [nchar](21) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Adresa] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Dobavljac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Dobavljac_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Dobavljac_IBAN] UNIQUE NONCLUSTERED 
(
	[IBAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Dobavljac_Naziv] UNIQUE NONCLUSTERED 
(
	[Naziv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Dobavljac_OIB] UNIQUE NONCLUSTERED 
(
	[OIB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farmaceut]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmaceut](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nchar](20) NOT NULL,
	[Prezime] [nchar](30) NOT NULL,
	[Korime] [nchar](20) NOT NULL,
	[Lozinka] [nchar](50) NOT NULL,
	[Adresa] [nchar](200) NULL,
	[Email] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Farmaceut] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Farmaceut_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Farmaceut_Korime] UNIQUE NONCLUSTERED 
(
	[Korime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JedinicaMjere]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JedinicaMjere](
	[ID] [nchar](3) NOT NULL,
	[Naziv] [nchar](10) NOT NULL,
 CONSTRAINT [PK_JedinicaMjere] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_JedinicaMjere] UNIQUE NONCLUSTERED 
(
	[Naziv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lijecnik]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lijecnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nchar](20) NOT NULL,
	[Prezime] [nchar](30) NOT NULL,
	[Adresa] [nchar](200) NULL,
	[Telefon] [nchar](20) NULL,
	[UstanovaID] [int] NOT NULL,
 CONSTRAINT [PK_Lijecnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzba]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzba](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[DobavljacID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[FarmaceutID] [int] NOT NULL,
 CONSTRAINT [PK_Narudzba] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacijent]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacijent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MBO] [nchar](9) NOT NULL,
	[Ime] [nchar](20) NOT NULL,
	[Prezime] [nchar](30) NOT NULL,
	[Adresa] [nchar](200) NULL,
	[DatumRodenja] [datetime] NULL,
 CONSTRAINT [PK_Pacijent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Pacijent_MBO] UNIQUE NONCLUSTERED 
(
	[MBO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Podaci]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Podaci](
	[Naziv] [nchar](50) NOT NULL,
	[Adresa] [nchar](200) NOT NULL,
	[OIB] [nchar](11) NOT NULL,
	[Telefon] [nchar](20) NOT NULL,
	[Logo] [varbinary](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Primka]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Primka](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DatumKnjizenja] [datetime] NOT NULL,
	[DobavljacID] [int] NOT NULL,
	[NarudzbaID] [int] NULL,
	[FarmaceutID] [int] NOT NULL,
 CONSTRAINT [PK_Primka] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[FarmaceutID] [int] NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recept]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recept](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime] NOT NULL,
	[LijecnikID] [int] NOT NULL,
	[PacijentID] [int] NOT NULL,
 CONSTRAINT [PK_Recept] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusNarudzbe]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusNarudzbe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nchar](15) NOT NULL,
 CONSTRAINT [PK_StatusNarudzbe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_StatusNarudzbe_Naziv] UNIQUE NONCLUSTERED 
(
	[Naziv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkeNarudzbe]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkeNarudzbe](
	[ArtiklID] [int] NOT NULL,
	[NarudzbaID] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_StavkeNarudzbe] PRIMARY KEY CLUSTERED 
(
	[ArtiklID] ASC,
	[NarudzbaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkePrimke]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkePrimke](
	[PrimkaID] [int] NOT NULL,
	[ArtiklID] [int] NOT NULL,
	[Kolicina] [int] NULL,
 CONSTRAINT [PK_StavkePrimke] PRIMARY KEY CLUSTERED 
(
	[PrimkaID] ASC,
	[ArtiklID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkeRacuna]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkeRacuna](
	[ArtiklID] [int] NOT NULL,
	[RacunID] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_StavkeRacuna] PRIMARY KEY CLUSTERED 
(
	[ArtiklID] ASC,
	[RacunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StavkeRecepta]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StavkeRecepta](
	[ReceptID] [int] NOT NULL,
	[ArtiklID] [int] NOT NULL,
	[Kolicina] [int] NULL,
 CONSTRAINT [PK_StavkeRecepta] PRIMARY KEY CLUSTERED 
(
	[ReceptID] ASC,
	[ArtiklID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ustanova]    Script Date: 6.8.2024. 18:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ustanova](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nchar](50) NOT NULL,
	[Adresa] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Ustanova] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Ustanova_Naziv] UNIQUE NONCLUSTERED 
(
	[Naziv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artikl]  WITH CHECK ADD  CONSTRAINT [FK_Artikl_JedinicaMjere] FOREIGN KEY([JedinicaMjereID])
REFERENCES [dbo].[JedinicaMjere] ([ID])
GO
ALTER TABLE [dbo].[Artikl] CHECK CONSTRAINT [FK_Artikl_JedinicaMjere]
GO
ALTER TABLE [dbo].[Lijecnik]  WITH CHECK ADD  CONSTRAINT [FK_Lijecnik_Ustanova] FOREIGN KEY([UstanovaID])
REFERENCES [dbo].[Ustanova] ([ID])
GO
ALTER TABLE [dbo].[Lijecnik] CHECK CONSTRAINT [FK_Lijecnik_Ustanova]
GO
ALTER TABLE [dbo].[Narudzba]  WITH CHECK ADD  CONSTRAINT [FK_Narudzba_Dobavljac] FOREIGN KEY([DobavljacID])
REFERENCES [dbo].[Dobavljac] ([ID])
GO
ALTER TABLE [dbo].[Narudzba] CHECK CONSTRAINT [FK_Narudzba_Dobavljac]
GO
ALTER TABLE [dbo].[Narudzba]  WITH CHECK ADD  CONSTRAINT [FK_Narudzba_Farmaceut] FOREIGN KEY([FarmaceutID])
REFERENCES [dbo].[Farmaceut] ([ID])
GO
ALTER TABLE [dbo].[Narudzba] CHECK CONSTRAINT [FK_Narudzba_Farmaceut]
GO
ALTER TABLE [dbo].[Narudzba]  WITH CHECK ADD  CONSTRAINT [FK_Narudzba_StatusNarudzbe] FOREIGN KEY([StatusID])
REFERENCES [dbo].[StatusNarudzbe] ([ID])
GO
ALTER TABLE [dbo].[Narudzba] CHECK CONSTRAINT [FK_Narudzba_StatusNarudzbe]
GO
ALTER TABLE [dbo].[Primka]  WITH CHECK ADD  CONSTRAINT [FK_Primka_Dobavljac] FOREIGN KEY([DobavljacID])
REFERENCES [dbo].[Dobavljac] ([ID])
GO
ALTER TABLE [dbo].[Primka] CHECK CONSTRAINT [FK_Primka_Dobavljac]
GO
ALTER TABLE [dbo].[Primka]  WITH CHECK ADD  CONSTRAINT [FK_Primka_Farmaceut] FOREIGN KEY([FarmaceutID])
REFERENCES [dbo].[Farmaceut] ([ID])
GO
ALTER TABLE [dbo].[Primka] CHECK CONSTRAINT [FK_Primka_Farmaceut]
GO
ALTER TABLE [dbo].[Primka]  WITH CHECK ADD  CONSTRAINT [FK_Primka_Narudzba] FOREIGN KEY([NarudzbaID])
REFERENCES [dbo].[Narudzba] ([ID])
GO
ALTER TABLE [dbo].[Primka] CHECK CONSTRAINT [FK_Primka_Narudzba]
GO
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Farmaceut] FOREIGN KEY([FarmaceutID])
REFERENCES [dbo].[Farmaceut] ([ID])
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Farmaceut]
GO
ALTER TABLE [dbo].[Recept]  WITH CHECK ADD  CONSTRAINT [FK_Recept_Lijecnik] FOREIGN KEY([LijecnikID])
REFERENCES [dbo].[Lijecnik] ([ID])
GO
ALTER TABLE [dbo].[Recept] CHECK CONSTRAINT [FK_Recept_Lijecnik]
GO
ALTER TABLE [dbo].[Recept]  WITH CHECK ADD  CONSTRAINT [FK_Recept_Pacijent] FOREIGN KEY([PacijentID])
REFERENCES [dbo].[Pacijent] ([ID])
GO
ALTER TABLE [dbo].[Recept] CHECK CONSTRAINT [FK_Recept_Pacijent]
GO
ALTER TABLE [dbo].[StavkeNarudzbe]  WITH CHECK ADD  CONSTRAINT [FK_StavkeNarudzbe_Artikl] FOREIGN KEY([ArtiklID])
REFERENCES [dbo].[Artikl] ([ID])
GO
ALTER TABLE [dbo].[StavkeNarudzbe] CHECK CONSTRAINT [FK_StavkeNarudzbe_Artikl]
GO
ALTER TABLE [dbo].[StavkeNarudzbe]  WITH CHECK ADD  CONSTRAINT [FK_StavkeNarudzbe_Narudzba] FOREIGN KEY([NarudzbaID])
REFERENCES [dbo].[Narudzba] ([ID])
GO
ALTER TABLE [dbo].[StavkeNarudzbe] CHECK CONSTRAINT [FK_StavkeNarudzbe_Narudzba]
GO
ALTER TABLE [dbo].[StavkePrimke]  WITH CHECK ADD  CONSTRAINT [FK_StavkePrimke_Artikl] FOREIGN KEY([ArtiklID])
REFERENCES [dbo].[Artikl] ([ID])
GO
ALTER TABLE [dbo].[StavkePrimke] CHECK CONSTRAINT [FK_StavkePrimke_Artikl]
GO
ALTER TABLE [dbo].[StavkePrimke]  WITH CHECK ADD  CONSTRAINT [FK_StavkePrimke_Primka] FOREIGN KEY([PrimkaID])
REFERENCES [dbo].[Primka] ([ID])
GO
ALTER TABLE [dbo].[StavkePrimke] CHECK CONSTRAINT [FK_StavkePrimke_Primka]
GO
ALTER TABLE [dbo].[StavkeRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkeRacuna_Artikl] FOREIGN KEY([ArtiklID])
REFERENCES [dbo].[Artikl] ([ID])
GO
ALTER TABLE [dbo].[StavkeRacuna] CHECK CONSTRAINT [FK_StavkeRacuna_Artikl]
GO
ALTER TABLE [dbo].[StavkeRacuna]  WITH CHECK ADD  CONSTRAINT [FK_StavkeRacuna_Racun] FOREIGN KEY([RacunID])
REFERENCES [dbo].[Racun] ([ID])
GO
ALTER TABLE [dbo].[StavkeRacuna] CHECK CONSTRAINT [FK_StavkeRacuna_Racun]
GO
ALTER TABLE [dbo].[StavkeRecepta]  WITH CHECK ADD  CONSTRAINT [FK_StavkeRecepta_Artikl] FOREIGN KEY([ArtiklID])
REFERENCES [dbo].[Artikl] ([ID])
GO
ALTER TABLE [dbo].[StavkeRecepta] CHECK CONSTRAINT [FK_StavkeRecepta_Artikl]
GO
ALTER TABLE [dbo].[StavkeRecepta]  WITH CHECK ADD  CONSTRAINT [FK_StavkeRecepta_Recept] FOREIGN KEY([ReceptID])
REFERENCES [dbo].[Recept] ([ID])
GO
ALTER TABLE [dbo].[StavkeRecepta] CHECK CONSTRAINT [FK_StavkeRecepta_Recept]
GO
ALTER TABLE [dbo].[Artikl]  WITH CHECK ADD  CONSTRAINT [CK_Artikl_Cijena] CHECK  (([Cijena]>=(0)))
GO
ALTER TABLE [dbo].[Artikl] CHECK CONSTRAINT [CK_Artikl_Cijena]
GO
ALTER TABLE [dbo].[Artikl]  WITH CHECK ADD  CONSTRAINT [CK_Artikl_Kolicina] CHECK  (([Kolicina]>=(0)))
GO
ALTER TABLE [dbo].[Artikl] CHECK CONSTRAINT [CK_Artikl_Kolicina]
GO
ALTER TABLE [dbo].[Artikl]  WITH CHECK ADD  CONSTRAINT [CK_Artikl_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[Artikl] CHECK CONSTRAINT [CK_Artikl_Naziv]
GO
ALTER TABLE [dbo].[Dobavljac]  WITH CHECK ADD  CONSTRAINT [CK_Dobavljac_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Dobavljac] CHECK CONSTRAINT [CK_Dobavljac_Adresa]
GO
ALTER TABLE [dbo].[Dobavljac]  WITH CHECK ADD  CONSTRAINT [CK_Dobavljac_Email] CHECK  (([Email]<>''))
GO
ALTER TABLE [dbo].[Dobavljac] CHECK CONSTRAINT [CK_Dobavljac_Email]
GO
ALTER TABLE [dbo].[Dobavljac]  WITH CHECK ADD  CONSTRAINT [CK_Dobavljac_IBAN] CHECK  ((len([IBAN])=(21)))
GO
ALTER TABLE [dbo].[Dobavljac] CHECK CONSTRAINT [CK_Dobavljac_IBAN]
GO
ALTER TABLE [dbo].[Dobavljac]  WITH CHECK ADD  CONSTRAINT [CK_Dobavljac_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[Dobavljac] CHECK CONSTRAINT [CK_Dobavljac_Naziv]
GO
ALTER TABLE [dbo].[Dobavljac]  WITH CHECK ADD  CONSTRAINT [CK_Dobavljac_OIB] CHECK  ((len([OIB])=(9)))
GO
ALTER TABLE [dbo].[Dobavljac] CHECK CONSTRAINT [CK_Dobavljac_OIB]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Adresa]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Email] CHECK  (([Email]<>''))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Email]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Ime] CHECK  (([Ime]<>''))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Ime]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Korime] CHECK  ((len([Korime])>=(5)))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Korime]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Lozinka] CHECK  ((len([Lozinka])>=(6)))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Lozinka]
GO
ALTER TABLE [dbo].[Farmaceut]  WITH CHECK ADD  CONSTRAINT [CK_Farmaceut_Prezime] CHECK  (([Prezime]<>''))
GO
ALTER TABLE [dbo].[Farmaceut] CHECK CONSTRAINT [CK_Farmaceut_Prezime]
GO
ALTER TABLE [dbo].[JedinicaMjere]  WITH CHECK ADD  CONSTRAINT [CK_JedinicaMjere_ID] CHECK  (([ID]<>''))
GO
ALTER TABLE [dbo].[JedinicaMjere] CHECK CONSTRAINT [CK_JedinicaMjere_ID]
GO
ALTER TABLE [dbo].[JedinicaMjere]  WITH CHECK ADD  CONSTRAINT [CK_JedinicaMjere_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[JedinicaMjere] CHECK CONSTRAINT [CK_JedinicaMjere_Naziv]
GO
ALTER TABLE [dbo].[Lijecnik]  WITH CHECK ADD  CONSTRAINT [CK_Lijecnik_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Lijecnik] CHECK CONSTRAINT [CK_Lijecnik_Adresa]
GO
ALTER TABLE [dbo].[Lijecnik]  WITH CHECK ADD  CONSTRAINT [CK_Lijecnik_Ime] CHECK  (([Ime]<>''))
GO
ALTER TABLE [dbo].[Lijecnik] CHECK CONSTRAINT [CK_Lijecnik_Ime]
GO
ALTER TABLE [dbo].[Lijecnik]  WITH CHECK ADD  CONSTRAINT [CK_Lijecnik_Prezime] CHECK  (([Prezime]<>''))
GO
ALTER TABLE [dbo].[Lijecnik] CHECK CONSTRAINT [CK_Lijecnik_Prezime]
GO
ALTER TABLE [dbo].[Lijecnik]  WITH CHECK ADD  CONSTRAINT [CK_Lijecnik_Telefon] CHECK  (([Telefon]<>''))
GO
ALTER TABLE [dbo].[Lijecnik] CHECK CONSTRAINT [CK_Lijecnik_Telefon]
GO
ALTER TABLE [dbo].[Pacijent]  WITH CHECK ADD  CONSTRAINT [CK_Pacijent_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Pacijent] CHECK CONSTRAINT [CK_Pacijent_Adresa]
GO
ALTER TABLE [dbo].[Pacijent]  WITH CHECK ADD  CONSTRAINT [CK_Pacijent_Ime] CHECK  (([Ime]<>''))
GO
ALTER TABLE [dbo].[Pacijent] CHECK CONSTRAINT [CK_Pacijent_Ime]
GO
ALTER TABLE [dbo].[Pacijent]  WITH CHECK ADD  CONSTRAINT [CK_Pacijent_MBO] CHECK  ((len([MBO])=(9)))
GO
ALTER TABLE [dbo].[Pacijent] CHECK CONSTRAINT [CK_Pacijent_MBO]
GO
ALTER TABLE [dbo].[Pacijent]  WITH CHECK ADD  CONSTRAINT [CK_Pacijent_Prezime] CHECK  (([Prezime]<>''))
GO
ALTER TABLE [dbo].[Pacijent] CHECK CONSTRAINT [CK_Pacijent_Prezime]
GO
ALTER TABLE [dbo].[Podaci]  WITH CHECK ADD  CONSTRAINT [CK_Podaci_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Podaci] CHECK CONSTRAINT [CK_Podaci_Adresa]
GO
ALTER TABLE [dbo].[Podaci]  WITH CHECK ADD  CONSTRAINT [CK_Podaci_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[Podaci] CHECK CONSTRAINT [CK_Podaci_Naziv]
GO
ALTER TABLE [dbo].[Podaci]  WITH CHECK ADD  CONSTRAINT [CK_Podaci_OIB] CHECK  ((len([OIB])=(11)))
GO
ALTER TABLE [dbo].[Podaci] CHECK CONSTRAINT [CK_Podaci_OIB]
GO
ALTER TABLE [dbo].[Podaci]  WITH CHECK ADD  CONSTRAINT [CK_Podaci_Telefon] CHECK  (([Telefon]<>''))
GO
ALTER TABLE [dbo].[Podaci] CHECK CONSTRAINT [CK_Podaci_Telefon]
GO
ALTER TABLE [dbo].[StatusNarudzbe]  WITH CHECK ADD  CONSTRAINT [CK_StatusNarudzbe_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[StatusNarudzbe] CHECK CONSTRAINT [CK_StatusNarudzbe_Naziv]
GO
ALTER TABLE [dbo].[StavkeNarudzbe]  WITH CHECK ADD  CONSTRAINT [CK_StavkeNarudzbe_Kolicina] CHECK  (([Kolicina]>(0)))
GO
ALTER TABLE [dbo].[StavkeNarudzbe] CHECK CONSTRAINT [CK_StavkeNarudzbe_Kolicina]
GO
ALTER TABLE [dbo].[StavkePrimke]  WITH CHECK ADD  CONSTRAINT [CK_StavkePrimke_Kolicina] CHECK  (([Kolicina]>(0)))
GO
ALTER TABLE [dbo].[StavkePrimke] CHECK CONSTRAINT [CK_StavkePrimke_Kolicina]
GO
ALTER TABLE [dbo].[StavkeRacuna]  WITH CHECK ADD  CONSTRAINT [CK_StavkeRacuna_Kolicina] CHECK  (([Kolicina]>(0)))
GO
ALTER TABLE [dbo].[StavkeRacuna] CHECK CONSTRAINT [CK_StavkeRacuna_Kolicina]
GO
ALTER TABLE [dbo].[StavkeRecepta]  WITH CHECK ADD  CONSTRAINT [CK_StavkeRecepta_Kolicina] CHECK  (([Kolicina]>(0)))
GO
ALTER TABLE [dbo].[StavkeRecepta] CHECK CONSTRAINT [CK_StavkeRecepta_Kolicina]
GO
ALTER TABLE [dbo].[Ustanova]  WITH CHECK ADD  CONSTRAINT [CK_Ustanova_Adresa] CHECK  (([Adresa]<>''))
GO
ALTER TABLE [dbo].[Ustanova] CHECK CONSTRAINT [CK_Ustanova_Adresa]
GO
ALTER TABLE [dbo].[Ustanova]  WITH CHECK ADD  CONSTRAINT [CK_Ustanova_Naziv] CHECK  (([Naziv]<>''))
GO
ALTER TABLE [dbo].[Ustanova] CHECK CONSTRAINT [CK_Ustanova_Naziv]
GO
