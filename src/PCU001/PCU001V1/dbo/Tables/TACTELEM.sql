CREATE TABLE [dbo].[TACTELEM] (
    [SKL_ID]             CHAR (4)    NOT NULL,
    [SKL_ELEM_SQNBR]     TINYINT     NOT NULL,
    [SKL_ELEM_CRT_SQNBR] TINYINT     NULL,
    [CRS_ID]             NCHAR (10)  NOT NULL,
    [TCHR_UID]           VARCHAR (7) NOT NULL,
    [PLN_VSN_CDTTM]      DATETIME    NOT NULL,
    [SMSTR_ID]           CHAR (3)    NOT NULL,
    [ACTVT_SQNBR]        SMALLINT    NOT NULL,
    [RCD_CDTTM]          DATETIME    CONSTRAINT [DF_TACTELEM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]            VARCHAR (7) NULL,
    CONSTRAINT [PK_TACTELEM] PRIMARY KEY CLUSTERED ([SKL_ELEM_SQNBR] ASC, [SKL_ID] ASC, [CRS_ID] ASC, [TCHR_UID] ASC, [PLN_VSN_CDTTM] ASC, [SMSTR_ID] ASC, [ACTVT_SQNBR] ASC),
    CONSTRAINT [FK_TACTELEM_TCRSACTVT] FOREIGN KEY ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID], [ACTVT_SQNBR]) REFERENCES [dbo].[TCRSACTVT] ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID], [ACTVT_SQNBR]),
    CONSTRAINT [FK_TACTELEM_TSKLELEM] FOREIGN KEY ([SKL_ID], [SKL_ELEM_SQNBR], [SKL_ELEM_CRT_SQNBR]) REFERENCES [dbo].[TSKLELEMCRT] ([SKL_ID], [SKL_ELEM_SQNBR], [SKL_ELEM_CRT_SQNBR])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Association activité -- élément de compétence', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TACTELEM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TACTELEM', @level2type = N'COLUMN', @level2name = N'CRS_ID';

