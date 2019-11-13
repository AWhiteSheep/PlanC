CREATE TABLE [dbo].[TCRSMTRL] (
    [CRS_ID]         NCHAR (10)     NOT NULL,
    [TCHR_UID]       VARCHAR (7)    NOT NULL,
    [PLN_VSN_CDTTM]  DATETIME       NOT NULL,
    [SMSTR_ID]       CHAR (3)       NOT NULL,
    [CRS_MTRL_SQNBR] SMALLINT       NOT NULL,
    [CRS_MTRL_DESC]  NVARCHAR (255) NULL,
    [RCD_CDTTM]      DATETIME       CONSTRAINT [DF_TCRSMTRL_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]        VARCHAR (7)    NULL,
    CONSTRAINT [PK_TCRSMTRL] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [TCHR_UID] ASC, [PLN_VSN_CDTTM] ASC, [SMSTR_ID] ASC, [CRS_MTRL_SQNBR] ASC),
    CONSTRAINT [FK_TCRSMTRL_TCRSPLN] FOREIGN KEY ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID]) REFERENCES [dbo].[TCRSPLN] ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Matériel requis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSMTRL';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSMTRL', @level2type = N'COLUMN', @level2name = N'CRS_ID';

