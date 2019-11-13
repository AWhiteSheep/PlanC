CREATE TABLE [dbo].[TCRSPLN] (
    [CRS_ID]        NCHAR (10)  NOT NULL,
    [TCHR_UID]      VARCHAR (7) NOT NULL,
    [PLN_VSN_CDTTM] DATETIME    NOT NULL,
    [SMSTR_ID]      CHAR (3)    NOT NULL,
    [RCD_CDTTM]     DATETIME    CONSTRAINT [DF_TCRSPLN_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]       VARCHAR (7) NULL,
    CONSTRAINT [PK_TCRSPLN] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [TCHR_UID] ASC, [PLN_VSN_CDTTM] ASC, [SMSTR_ID] ASC),
    CONSTRAINT [FK_TCRSPLN_TSMSTR] FOREIGN KEY ([SMSTR_ID]) REFERENCES [dbo].[TSMSTR] ([SMSTR_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Plan de cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSPLN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSPLN', @level2type = N'COLUMN', @level2name = N'CRS_ID';

