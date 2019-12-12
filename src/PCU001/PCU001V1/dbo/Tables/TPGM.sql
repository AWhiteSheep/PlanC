CREATE TABLE [dbo].[TPGM] (
    [PGM_ID]                          CHAR (6)       NOT NULL,
    [DPTMNT_ID]                       INT            NOT NULL,
    [PGM_TITLE]                       NVARCHAR (50)  NULL,
    [PGM_DESC]                        NTEXT          NULL,
    [PGM_PDF]                         NTEXT          NULL,
    [PMG_IMG]                         NVARCHAR (MAX) NULL,
    [PGM_TY_CD]                       CHAR (2)       NULL,
    [NUMB_OBLIGATED_SKILL]            INT            NULL,
    [NUMB_NONREQUIRED_SKILL]          INT            NULL,
    [NUMB_OBLIGATCOMPLEMENTARY_SKILL] INT            NULL,
    [PGM_TY_FORM]                     CHAR (3)       NULL,
    [RCD_CDTTM]                       DATETIME       CONSTRAINT [DF_TPGM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]                         VARCHAR (7)    NULL,
    PRIMARY KEY CLUSTERED ([PGM_ID] ASC, [DPTMNT_ID] ASC),
    CONSTRAINT [FK_TPGM_TCDTY] FOREIGN KEY ([PGM_TY_CD]) REFERENCES [dbo].[TCDTY] ([CD_TY]),
    CONSTRAINT [FK_TPGM_TDPTMNT] FOREIGN KEY ([DPTMNT_ID]) REFERENCES [dbo].[TDPTMNT] ([DPTMNT_ID]),
    CONSTRAINT [FK_TPGM_TPMGFORMTYPE] FOREIGN KEY ([PGM_TY_FORM]) REFERENCES [dbo].[TPMGFORMTYPE] ([ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Programme d''études', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TPGM';

