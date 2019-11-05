USE PCU001
GO


INSERT INTO TDPTMNT
(
	DPTMNT_TITLE,
	DPTMNT_PLCY,
	TRK_UID
)
VALUES
(
	'Département d''informatique',
	'Le français est important. Les retards aussi',
	'11111'
),
(
	'Département des soins infirmiers',
	'Le français est important. Les retards ne le sont pas.',
	'22222'
),
(
	'Département des soins infirmiers',
	'Le français est important. Les retards ne le sont pas.',
	'22222'
),
(
	'Département de français',
	'Le français est important. Les retard blabla',
	'33333'
)
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