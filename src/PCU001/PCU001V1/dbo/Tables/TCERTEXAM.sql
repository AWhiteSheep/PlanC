CREATE TABLE [dbo].[TCERTEXAM] (
    [CRS_ID]        NCHAR (10)  NOT NULL,
    [TCHR_UID]      VARCHAR (7) NOT NULL,
    [PLN_VSN_CDTTM] DATETIME    NOT NULL,
    [SMSTR_ID]      CHAR (3)    NOT NULL,
    [EXAM_ID]       INT         NOT NULL,
    [RCD_CDTTM]     DATETIME    CONSTRAINT [DF_TCERTEXAM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]       VARCHAR (7) NULL,
    CONSTRAINT [PK_TCERTEXAM] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [TCHR_UID] ASC, [PLN_VSN_CDTTM] ASC, [SMSTR_ID] ASC, [EXAM_ID] ASC),
    CONSTRAINT [FK_TCERTEXAM_TCRSPLN] FOREIGN KEY ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID]) REFERENCES [dbo].[TCRSPLN] ([CRS_ID], [TCHR_UID], [PLN_VSN_CDTTM], [SMSTR_ID]),
    CONSTRAINT [FK_TCERTEXAM_TEXAM] FOREIGN KEY ([EXAM_ID]) REFERENCES [dbo].[TEXAM] ([EXAM_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Examen certificatif', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCERTEXAM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCERTEXAM', @level2type = N'COLUMN', @level2name = N'CRS_ID';

