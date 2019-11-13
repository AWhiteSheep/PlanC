CREATE TABLE [dbo].[TSKLELEM] (
    [SKL_ID]        CHAR (4)       NOT NULL,
    [SKLELEM_SQNBR] TINYINT        NOT NULL,
    [SKLELEM_TITLE] NVARCHAR (255) NULL,
    [SKLELEM_DESC]  NTEXT          NULL,
    [RCD_CDTTM]     DATETIME       CONSTRAINT [DF_TSKLELEM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]       VARCHAR (7)    NULL,
    CONSTRAINT [PK_TSKLELEM] PRIMARY KEY CLUSTERED ([SKL_ID] ASC, [SKLELEM_SQNBR] ASC),
    CONSTRAINT [FK_TSKLELEM_TSKL] FOREIGN KEY ([SKL_ID]) REFERENCES [dbo].[TSKL] ([SKL_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Élément de compétence', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TSKLELEM';

