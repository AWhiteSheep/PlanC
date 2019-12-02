﻿CREATE TABLE [dbo].[TSKLELEMCRT] (
    [SKL_ID]             CHAR (4)       NOT NULL,
    [SKL_ELEM_SQNBR]     TINYINT        NOT NULL,
    [SKL_ELEM_CRT_SQNBR] TINYINT        NOT NULL,
    [SKL_ELEM_CRT_TITLE] NVARCHAR (MAX) NULL,
    [RCD_CDTTM]          DATETIME       CONSTRAINT [DF_TSKLELEMCRT_RCD_CDTTM] DEFAULT (getdate()) NOT NULL,
    [TRK_UID]            VARCHAR (7)    DEFAULT ('ANO') NOT NULL,
    CONSTRAINT [PK_TSKLELEMCRT] PRIMARY KEY CLUSTERED ([SKL_ID] ASC, [SKL_ELEM_SQNBR] ASC, [SKL_ELEM_CRT_SQNBR] ASC),
    CONSTRAINT [FK_TSKLELEMCRT_TSKLELEM] FOREIGN KEY ([SKL_ID], [SKL_ELEM_SQNBR]) REFERENCES [dbo].[TSKLELEM] ([SKL_ID], [SKLELEM_SQNBR])
);
