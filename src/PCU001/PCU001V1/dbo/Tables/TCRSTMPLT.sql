CREATE TABLE [dbo].[TCRSTMPLT] (
    [CRS_ID]          NCHAR (10)     NOT NULL,
    [VSN_CDTTM]       DATETIME       NOT NULL,
    [PGM_ID]          CHAR (6)       NULL,
    [CRS_TITLE]       NVARCHAR (50)  NULL,
    [UNITS]           DECIMAL (3, 2) NULL,
    [CRS_DESC]        NTEXT          NULL,
    [CRS_EDU_INTENT]  NTEXT          NULL,
    [CRS_PDG_INTENT]  NTEXT          NULL,
    [THEORY_HRS]      INT            NULL,
    [PRCT_HRS]        INT            NULL,
    [HOME_HRS]        INT            NULL,
    [DPTMNT_APPRV_DT] DATE           NULL,
    [CMTE_APPRV_DT]   DATE           NULL,
    [BOARD_APPRV_DT]  DATE           NULL,
    [TRK_UID]         VARCHAR (7)    NULL,
    [RCD_CDTTM]       DATETIME       CONSTRAINT [DF_TCRSTMPLT_RCD_CDTTM] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_TCRSTMPLT] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [VSN_CDTTM] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Plan-cadre', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSTMPLT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSTMPLT', @level2type = N'COLUMN', @level2name = N'CRS_ID';

