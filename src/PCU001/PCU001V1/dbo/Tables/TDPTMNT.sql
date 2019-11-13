CREATE TABLE [dbo].[TDPTMNT] (
    [DPTMNT_ID]    INT            NOT NULL,
    [DPTMNT_TITLE] NVARCHAR (250) NULL,
    [DPTMNT_PLCY]  NTEXT          NULL,
    [RCD_CDTTM]    DATETIME       CONSTRAINT [DF_TDPTMNT_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]      VARCHAR (7)    NULL,
    CONSTRAINT [PK_TDPTMNT] PRIMARY KEY CLUSTERED ([DPTMNT_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Département', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TDPTMNT';

