CREATE TABLE [dbo].[TSMSTR] (
    [SMSTR_ID]   CHAR (3)      NOT NULL,
    [SMSTR_DESC] NVARCHAR (50) NULL,
    [SMSTR_SDT]  DATE          NULL,
    [SMSTR_NDT]  DATE          NULL,
    [RCD_CDTTM]  DATETIME      CONSTRAINT [DF_TSMSTR_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]    VARCHAR (7)   NULL,
    CONSTRAINT [PK_TSMSTR] PRIMARY KEY CLUSTERED ([SMSTR_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Session', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TSMSTR';

