CREATE TABLE [dbo].[TEXAM] (
    [EXAM_ID]    INT            NOT NULL,
    [EXAM_TY_CD] CHAR (2)       NULL,
    [EXAM_TITLE] NVARCHAR (150) NULL,
    [EXAM_WGHT]  DECIMAL (5, 2) NULL,
    [RCD_CDTTM]  DATETIME       CONSTRAINT [DF_TEXAM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]    VARCHAR (7)    NULL,
    CONSTRAINT [PK_TEXAM] PRIMARY KEY CLUSTERED ([EXAM_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Entité de base pour un examen', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TEXAM';

