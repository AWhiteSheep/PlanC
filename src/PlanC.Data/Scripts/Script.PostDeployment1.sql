/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [dbo].[TDPTMNT] ON
INSERT INTO [dbo].[TDPTMNT] ([DPTMNT_ID], [DPTMNT_TITLE], [DPTMNT_PLCY], [RCD_CDTTM], [TRK_UID]) VALUES (1, N'Département d''informatique', N'<h6>
ABSENCE AUX COURS ET LABORATOIRES
Il</h6>est essentiel que les étudiantes et les étudiants réalisent qu''ils partagent avec l’enseignante la responsabilité de leur apprentissage. Elles et ils doivent assister à toutes les séances de cours et de laboratoire et faire tous leurs travaux afin d’atteindre les compétences souhaitées. « L’étudiante ou étudiant qui s’absente pour un cours ou une partie de période de cours doit récupérer par lui-même les apprentissages manquants. » (PIEA 6.8)
RETARD AUX COURS
Il est attendu que l’étudiante ou l’étudiant qui arrive en retard attend la pause (ou que l’enseignante ouvre la porte) pour entrer dans le local afin de ne pas interrompre le cours. Les retardataires ne doivent en aucun cas déranger la classe.
RETARD DANS LA REMISE DES TRAVAUX
Les travaux doivent être remis très spécifiquement selon les modalités énoncées (par écrit, par LÉA, vérification sur le poste directement, etc.). Tout retard à la remise de travaux selon les modalités énoncées entraîne automatiquement la note de zéro (0).
ABSENCE À UNE ÉVALUATION
« L’étudiante ou étudiant qui ne se présente pas à une évaluation certificative (examen, remise de travaux, etc.) prévue au calendrier obtient la note « 0 » (zéro) à moins qu’il ne justifie son absence à l’enseignante ou enseignant. Si l’enseignante ou enseignant accepte la justification, une reprise de l’évaluation sommative manquée est accordée à l’étudiante ou étudiant. Les modalités de reprise de l’évaluation sont alors déterminées par l''enseignante ou enseignant. » (PIEA 6.4)
PLAGIAT
Toute personne prise à plagier, ou qui en a été complice, se voit automatiquement attribuer la note de zéro (0) pour l’activité. Il est à noter que « l’enseignante ou enseignant a la responsabilité de dénoncer les cas de fraude scolaire et de plagiat. » (PIEA 6.9)
RÉVISION DE NOTES
L’étudiante ou l’étudiant qui n''est pas satisfait de son évaluation (et non pas de sa note) peut demander une révision de note au service de l''organisation scolaire dans les délais prévus par celle-ci. Advenant une erreur évidente (travail non comptabilisé, erreur de saisie...) il peut aussi en aviser immédiatement l’enseignante qui fera la correction.
QUALITÉ DU FRANÇAIS
Pour tous les travaux écrits et les examens, 10% de la note finale est réservée à la qualité du français (orthographe, grammaire, syntaxe, etc.). 
CONSOMMATION DE NOURRITURE ET BOISSONS
Aucune nourriture (collation et repas) ne sera tolérée dans les laboratoires informatiques. Les seuls breuvages acceptés sont les suivants : eau, jus, café et autres du même genre. Ils doivent être dans une bouteille fermée ou dans un gobelet antifuite.
UTILISATION ET RANGEMENT DU MATÉRIEL
Il est strictement interdit de déplacer ou débrancher le matériel (écrans, ordinateurs, souris, câble réseau du cégep, etc.) informatique qui se trouve dans la classe sans l’autorisation de l’enseignant.  Si l’enseignant l’autorise, le matériel installé devra être enlevé à la fin de chaque cours, et le poste de travail devra être remis à son état initial.
', N'2019-11-08 09:33:12', N'11111')
INSERT INTO [dbo].[TDPTMNT] ([DPTMNT_ID], [DPTMNT_TITLE], [DPTMNT_PLCY], [RCD_CDTTM], [TRK_UID]) VALUES (2, N'Département des soins infirmiers', N'<h6>ABSENCE AUX COURS ET LABORATOIRES</h6>Il est essentiel que les étudiantes et les étudiants réalisent qu''ils partagent avec l’enseignante la responsabilité de leur apprentissage. Elles et ils doivent assister à toutes les séances de cours et de laboratoire et faire tous leurs travaux afin d’atteindre les compétences souhaitées. « L’étudiante ou étudiant qui s’absente pour un cours ou une partie de période de cours doit récupérer par lui-même les apprentissages manquants. » (PIEA 6.8)
<h6>RETARD AUX COURS</h6>Il est attendu que l’étudiante ou l’étudiant qui arrive en retard attend la pause (ou que l’enseignante ouvre la porte) pour entrer dans le local afin de ne pas interrompre le cours. Les retardataires ne doivent en aucun cas déranger la classe.
<h6>RETARD DANS LA REMISE DES TRAVAUX</h6>Les travaux doivent être remis très spécifiquement selon les modalités énoncées (par écrit, par LÉA, vérification sur le poste directement, etc.). Tout retard à la remise de travaux selon les modalités énoncées entraîne automatiquement la note de zéro (0).
<h6>ABSENCE À UNE ÉVALUATION</h6>« L’étudiante ou étudiant qui ne se présente pas à une évaluation certificative (examen, remise de travaux, etc.) prévue au calendrier obtient la note « 0 » (zéro) à moins qu’il ne justifie son absence à l’enseignante ou enseignant. Si l’enseignante ou enseignant accepte la justification, une reprise de l’évaluation sommative manquée est accordée à l’étudiante ou étudiant. Les modalités de reprise de l’évaluation sont alors déterminées par l''enseignante ou enseignant. » (PIEA 6.4)
', N'2019-11-08 09:33:12', N'22222')
INSERT INTO [dbo].[TDPTMNT] ([DPTMNT_ID], [DPTMNT_TITLE], [DPTMNT_PLCY], [RCD_CDTTM], [TRK_UID]) VALUES (3, N'Département des soins infirmiers', N'ORGANISATION

L’élève a la responsabilité d’assurer sa présence en classe. L’élève qui arrive en retard au cours doit attendre la pause pour entrer, à moins qu’il y soit invité par l’enseignant.

Dans le cas d’une absence motivée, vous êtes invité à informer votre enseignant par COURRIER ÉLECTRONIQUE le plus rapidement possible.


JEUX ET CLAVARDAGE EN CLASSE

Il est essentiel que l’élève participe de façon active et qu’un climat propice à l’apprentissage soit maintenu dans la classe. Dans cette optique, les jeux, le clavardage (chat) et toute autre distraction cybernétique sont interdits en tout temps durant les cours (incluant les pauses). En cas de non-respect de cette règle, l’expulsion immédiate du local de l’étudiant pour le reste de la rencontre (séance de cours) sera imposée par l’enseignant. En cas de récidive par l’étudiant, une convocation avec le comité de discipline sera prévue avec les sanctions appropriées.
', N'2019-11-08 09:33:12', N'22222')
INSERT INTO [dbo].[TDPTMNT] ([DPTMNT_ID], [DPTMNT_TITLE], [DPTMNT_PLCY], [RCD_CDTTM], [TRK_UID]) VALUES (4, N'Département de français', N'ORGANISATION

L’élève a la responsabilité d’assurer sa présence en classe. L’élève qui arrive en retard au cours doit attendre la pause pour entrer, à moins qu’il y soit invité par l’enseignant.

Dans le cas d’une absence motivée, vous êtes invité à informer votre enseignant par COURRIER ÉLECTRONIQUE le plus rapidement possible.


JEUX ET CLAVARDAGE EN CLASSE

Il est essentiel que l’élève participe de façon active et qu’un climat propice à l’apprentissage soit maintenu dans la classe. Dans cette optique, les jeux, le clavardage (chat) et toute autre distraction cybernétique sont interdits en tout temps durant les cours (incluant les pauses). En cas de non-respect de cette règle, l’expulsion immédiate du local de l’étudiant pour le reste de la rencontre (séance de cours) sera imposée par l’enseignant. En cas de récidive par l’étudiant, une convocation avec le comité de discipline sera prévue avec les sanctions appropriées.
', N'2019-11-08 09:33:12', N'33333')

GO

--TODO : Attent minute. Ne serait-il pas mieux que ce soient les cours qui soient associés aux département, plutôt que les programmes?
INSERT INTO TPGM
(
	PGM_ID,
	DPTMNT_ID,
	PGM_TITLE,
	PGM_DESC,
	PGM_TY_CD,
	TRK_UID
)
VALUES
(
	'420.B0',
	1,
	'Technique de l’informatique',
	'Le programme d’études Techniques de l’informatique vise à former des techniciennes ou techniciens en informatique qui exerceront leur profession dans les domaines du développement d’applications et de l’administration des réseaux informatiques.',
	'AA',
	'11111'
),
(
	'180.A0',
	2,
	'Technique des soins infirmiers',
	'Les personnes professionnelles de la santé doivent se préparer à assumer de nouveaux rôles et à relever des défis reliés aux changements scientifiques, technologiques, organisationnels et politiques. Le programme Soins infirmiers 180.A0 s’inscrit dans le cadre de ces changements et vise à former des personnes aptes à exercer la profession d’une façon autonome et responsable.',
	'BB',
	'22222'
),
(
	'ZZZ.FR',
	4,
	'Formation générale/Français',
	'Dans la vie, il est important de bien écrire. C’est pourquoi le programe de français existe.',
	'CC',
	'33333'
)
GO


--Compétences
--TODO : Dans le devis, les compétences sont soit obligatoires ou 'au choix'
INSERT INTO TSKL
(
	SKL_ID,
	PGM_ID,
	SKL_TITLE,
	ASSC_ATTD,
	TRK_UID
)
VALUES
( --Obligatoire
	'00Q1',
	'420.B0',
	'Effectuer l’installation et la gestion d’ordinateurs',
	'Des attitudes',
	'11111'
),
( --Au choix
	'00SJ',
	'420.B0',
	'Effectuer le déploiement de serveurs intranet',
	'Des attitudes',
	'11111'
),
( --Général commun
	'4EF1',
	null,
	'Expliquer les représentations du monde contenues dans des textes littéraires d’époques et de genres variés',
	'Des attitudes',
	'11111'
),
( --Général propre
	'4SAP',
	null,
	'Communiquer en anglais de façon simple en utilisant des formes d’expression d’usage courant liées au champ d’études de l’élève',
	'Des attitudes',
	'11111'
)
GO


--Éléments de compétence
INSERT INTO TSKLELEM
(
	SKL_ID,
	SKLELEM_SQNBR,
	SKLELEM_TITLE,
	TRK_UID
)
VALUES
--00Q1
(
	'00Q1',
	0,
	'Préparer l’ordinateur',
	'11111'
),
(
	'00Q1',
	1,
	'Installer le système d’exploitation',
	'11111'
),
(
	'00Q1',
	2,
	'Installer des applications',
	'11111'
),
(
	'00Q1',
	3,
	'Effectuer des tâches de gestion du système d’exploitation',
	'11111'
),
--00SJ
(
	'00SJ',
	0,
	'Analyser le projet de déploiement',
	'11111'
),
(
	'00SJ',
	1,
	'Monter les serveurs intranet',
	'11111'
),
(
	'00SJ',
	2,
	'Installer les services intranet',
	'11111'
),
(
	'00SJ',
	3,
	'Procéder au renforcement de la sécurité',
	'11111'
),
(
	'00SJ',
	4,
	'Participer à la mise en service des serveurs intranet',
	'11111'
),
(
	'00SJ',
	5,
	'Rédiger la documentation',
	'11111'
),
--4EF1
(
	'4EF1',
	0,
	'Reconnaître le traitement d’un thème dans un texte',
	'11111'
),
(
	'4EF1',
	1,
	'Situer le texte dans son contexte culturel et sociohistorique',
	'11111'
),
(
	'4EF1',
	2,
	'Dégager les rapports entre le réel, le langage et l’imaginaire',
	'11111'
),
(
	'4EF1',
	3,
	'Élaborer un plan de dissertation',
	'11111'
),
(
	'4EF1',
	4,
	'Rédiger une dissertation explicative',
	'11111'
),
(
	'4EF1',
	5,
	'Réviser et corriger le texte',
	'11111'
),
--4SAP
(
	'4SAP',
	0,
	'Dégager le sens d’un message oral authentique lié à son champ d’études',
	'11111'
),
(
	'4SAP',
	1,
	'Dégager le sens d’un texte authentique lié à son champ d’études',
	'11111'
),
(
	'4SAP',
	2,
	'Communiquer un bref message oral lié à son champ d’études',
	'11111'
),
(
	'4SAP',
	3,
	'Rédiger et réviser un court texte lié à son champ d’études',
	'11111'
)
GO


--Contextes de réalisation
INSERT INTO TSKLCNTXT
(
	SKL_ID,
	SKL_CNTXT_SQNBR,
	SKL_CNTXT_TITLE,
	TRK_UID
)
VALUES
--00Q1
(
	'00Q1',
	0,
	'Pour différents systèmes d’exploitation.',
	'22222'
),
(
	'00Q1',
	1,
	'À partir d’une demande.',
	'22222'
),
(
	'00Q1',
	2,
	'À l’aide d’ordinateurs, de périphériques, de composants internes amovibles, etc.',
	'22222'
),
(
	'00Q1',
	3,
	'À l’aide de la documentation technique.',
	'22222'
),
(
	'00Q1',
	4,
	'À partir d’une demande.',
	'22222'
),
--00SJ
(
	'00SJ',
	0,
	'Pour des serveurs intranet de différents types : physiques, virtualisés, redondants, distribués, etc.',
	'22222'
),
(
	'00SJ',
	1,
	'Pour différents services : authentification, annuaire, impression, partage de fichiers, téléphonie, DHCP, etc.',
	'22222'
)
--4EF1
--(Aucun)
--4SAP
--(Aucun)
GO


--Critères de performance
INSERT INTO TSKLELEMCRT
(
	SKL_ID,
	SKL_ELEM_SQNBR,
	SKL_ELEM_CRT_SQNBR,
	SKL_ELEM_CRT_TITLE,
	TRK_UID
)
VALUES
(
	'00Q1',
	0,
	0,
	'Interprétation juste de la demande.',
	'11111'
),
(
	'00Q1',
	0,
	1,
	'Interprétation juste des spécifications de l’équipement informatique.',
	'11111'
),
(
	'00Q1',
	0,
	2,
	'Ajout correct de composants amovibles.',
	'11111'
),
(
	'00Q1',
	0,
	3,
	'Raccordement correct des périphériques.',
	'11111'
),
(
	'00Q1',
	0,
	4,
	'Positionnement ergonomique de l’ordinateur et de ses périphériques.',
	'11111'
),
(
	'00Q1',
	1,
	0,
	'Utilisation appropriée des utilitaires de préparation des systèmes de fichiers.',
	'11111'
),
(
	'00Q1',
	2,
	0,
	'Application correcte de la procédure d’installation des applications et des modules d’extension.',
	'11111'
),
(
	'00Q1',
	3,
	0,
	'Organisation fonctionnelle de la structure des fichiers et des répertoires.',
	'11111'
),
(
	'00SJ',
	0,
	0,
	'Analyse juste des documents de conception.',
	'11111'
),
(
	'00SJ',
	1,
	0,
	'Positionnement et fixation des serveurs et des périphériques conformes aux plans.',
	'11111'
),
(
	'4EF1',
	0,
	0,
	'Relevé des procédés stylistiques et littéraires utilisés pour le développement du thème.',
	'11111'
),
(
	'4SAP',
	0,
	0,
	'Reconnaissance du sens général et des idées essentielles du message.',
	'11111'
)