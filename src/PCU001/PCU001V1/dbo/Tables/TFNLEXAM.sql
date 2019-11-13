CREATE TABLE [dbo].[TFNLEXAM] (
    [CRS_ID]    NCHAR (10)  NOT NULL,
    [VSN_CDTTM] DATETIME    NOT NULL,
    [EXAM_ID]   INT         NOT NULL,
    [RCD_CDTTM] DATETIME    CONSTRAINT [DF_TFNLEXAM_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [TRK_UID]   VARCHAR (7) NULL,
    CONSTRAINT [PK_TFNLEXAM] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [VSN_CDTTM] ASC, [EXAM_ID] ASC),
    CONSTRAINT [FK_TFNLEXAM_TCRSTMPLT] FOREIGN KEY ([CRS_ID], [VSN_CDTTM]) REFERENCES [dbo].[TCRSTMPLT] ([CRS_ID], [VSN_CDTTM]),
    CONSTRAINT [FK_TFNLEXAM_TEXAM] FOREIGN KEY ([EXAM_ID]) REFERENCES [dbo].[TEXAM] ([EXAM_ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Examen certificatif final', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TFNLEXAM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TFNLEXAM', @level2type = N'COLUMN', @level2name = N'CRS_ID';

