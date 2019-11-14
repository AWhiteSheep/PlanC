CREATE TABLE [dbo].[TSKL] (
    [SKL_ID]                 CHAR (4)      NOT NULL,
    [SKL_TITLE]              VARCHAR (200) NULL,
    [ASSC_ATTD]              NTEXT         NULL,
    [SKL_DISCIPLINARY_FIELD] INT           NULL,
    [NB_PARTS_COMPLETED]     TINYINT       DEFAULT ((1)) NOT NULL,
    [CAN_BE_COMPLEMENTORY]   BIT           NULL,
    [RCD_CDTTM]              DATETIME      CONSTRAINT [DF_TSKL_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]                VARCHAR (7)   NULL,
    CONSTRAINT [PK_TSKL] PRIMARY KEY CLUSTERED ([SKL_ID] ASC),
    CONSTRAINT [FK_TSKL_TDPMNT] FOREIGN KEY ([SKL_DISCIPLINARY_FIELD]) REFERENCES [dbo].[TDPTMNT] ([DPTMNT_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Compétence', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TSKL';

