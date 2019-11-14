CREATE TABLE [dbo].[TCRSSKLELEM] (
    [CRS_ID]        NCHAR (10)  NOT NULL,
    [VSN_CDTTM]     DATETIME    NOT NULL,
    [SKL_ID]        CHAR (4)    NOT NULL,
    [SKLELEM_SQNBR] TINYINT     NOT NULL,
    [PRTL_SKL_IND]  CHAR (1)    NULL,
    [TXNMY_CD]      CHAR (2)    NULL,
    [ADDTNL_DESC]   NTEXT       NULL,
    [RCD_CDTTM]     DATETIME    CONSTRAINT [DF_TCRSSKLELEM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]       VARCHAR (7) NULL,
    CONSTRAINT [PK_TTMPLTSKLELEM] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [VSN_CDTTM] ASC, [SKL_ID] ASC, [SKLELEM_SQNBR] ASC),
    CONSTRAINT [FK_TTMPLTSKLELEM_TCRSTMPLT] FOREIGN KEY ([CRS_ID], [VSN_CDTTM]) REFERENCES [dbo].[TCRSTMPLT] ([CRS_ID], [VSN_CDTTM])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Association plan-cadre -- élément de compétence', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSSKLELEM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSSKLELEM', @level2type = N'COLUMN', @level2name = N'CRS_ID';

