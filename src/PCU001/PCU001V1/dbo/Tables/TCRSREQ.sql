CREATE TABLE [dbo].[TCRSREQ] (
    [CRS_ID]        NCHAR (10)  NOT NULL,
    [VSN_CDTTM]     DATETIME    NOT NULL,
    [REQ_CRS_ID]    NCHAR (10)  NOT NULL,
    [RCD_CDTTM]     DATETIME    CONSTRAINT [DF_TCRSREQ_RCD_CDTTM] DEFAULT (getdate()) NULL,
    [CRS_REQ_TY_CD] CHAR (2)    NULL,
    [TRK_UID]       VARCHAR (7) NULL,
    CONSTRAINT [PK_TCRSREQ] PRIMARY KEY CLUSTERED ([CRS_ID] ASC, [VSN_CDTTM] ASC, [REQ_CRS_ID] ASC),
    CONSTRAINT [FK_TCRSREQ_TCRSTMPLT] FOREIGN KEY ([CRS_ID], [VSN_CDTTM]) REFERENCES [dbo].[TCRSTMPLT] ([CRS_ID], [VSN_CDTTM])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Prérequis; corequis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSREQ';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Code d''identification d''un cours', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TCRSREQ', @level2type = N'COLUMN', @level2name = N'CRS_ID';

