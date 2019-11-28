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
	'D�partement d''informatique',
	'Le fran�ais est important. Les retards aussi',
	'11111'
),
(
	'D�partement des soins infirmiers',
	'Le fran�ais est important. Les retards ne le sont pas.',
	'22222'
),
(
	'D�partement des soins infirmiers',
	'Le fran�ais est important. Les retards ne le sont pas.',
	'22222'
),
(
	'D�partement de fran�ais',
	'Le fran�ais est important. Les retard blabla',
	'33333'
)
GO

--TODO : Attent minute. Ne serait-il pas mieux que ce soient les cours qui soient associ�s aux d�partement, plut�t que les programmes?
INSERT INTO TPGM
(
	PGM_ID,
	DPTMNT_ID,
	PGM_TITLE,
	PGM_DESC,
	PGM_TY_CD, --Type de programme
	TRK_UID
)
VALUES
(
	'420.AA',
	1,
	'Technique de l�informatique',
	'Le programme d��tudes Techniques de l�informatique vise � former des techniciennes ou techniciens en informatique qui exerceront leur profession dans les domaines du d�veloppement d�applications et de l�administration des r�seaux informatiques.',
	'TA',
	'11111'
),
(
	'420.B0',
	1,
	'Programmation et s�curit�',
	'Le programme d��tudes Techniques de l�informatique vise � former des techniciennes ou techniciens en
informatique dont la profession cible le d�veloppement d�applications ou l�administration des r�seaux
informatiques.
Dans le domaine du d�veloppement d�applications, les techniciennes et les techniciens participent � la
conception d�applications fonctionnant sur diff�rentes plateformes et en effectuent le d�veloppement et la
maintenance. Les applications d�velopp�es contribuent � des domaines vari�s dans presque tous les
secteurs d�activit� o� l�int�grit� de ses donn�es est la base de la conception.
Dans le domaine de l�administration des r�seaux informatiques, les techniciennes et les techniciens
participent � la conception de r�seaux, en effectuent l�installation, en fait sa gestion et la s�curisation de ses
serveurs et ordinateurs. Leur t�che consiste aussi � assurer le fonctionnement des services Internet et
intranet qui y sont li�s, tels le partage de ressources, la communication, l�h�bergement, la t�l�phonie, etc.
Ces personnes offrent �galement du soutien aux utilisatrices et aux utilisateurs.
Selon l�ampleur du projet, le travail est effectu� individuellement ou en collaboration avec diff�rents
sp�cialistes : autres techniciennes et techniciens en informatique, analystes, conseill�res ou conseillers en
architecture de donn�es ou de r�seaux, charg�es ou charg�s de projets, personnel responsable de
l�assurance qualit�, fournisseurs, etc.
L�environnement de travail est tr�s diversifi�. Il est souvent constitu� de composants mat�riels et logiciels �
la fine pointe des technologies, mais parfois de composants de g�n�rations ant�rieures. Le travail
demande donc une capacit� d�adaptation importante, un perfectionnement constant de ses connaissances,
d�excellentes capacit�s de raisonnement, l�application d�une d�marche structur�e, de la polyvalence, ainsi
que de l�ouverture d�esprit. ',
	'TA',
	'11111'
),
(
	'180.A0',
	2,
	'Technique des soins infirmiers',
	'Les personnes professionnelles de la sant� doivent se pr�parer � assumer de nouveaux r�les et � relever des d�fis reli�s aux changements scientifiques, technologiques, organisationnels et politiques. Le programme Soins infirmiers 180.A0 s�inscrit dans le cadre de ces changements et vise � former des personnes aptes � exercer la profession d�une fa�on autonome et responsable.',
	'TS',
	'22222'
),
(
	'ZZZ.FR',
	4,
	'Formation g�n�rale/Fran�ais',
	'Dans la vie, il est important de bien �crire. C�est pourquoi le programe de fran�ais existe.',
	'PH',
	'33333'
)
GO


--Comp�tences
--TODO : Dans le devis, les comp�tences sont soit obligatoires ou 'au choix'
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
	'Effectuer l�installation et la gestion d�ordinateurs',
	'Des attitudes',
	'11111'
),
( --Au choix
	'00SJ',
	'420.B0',
	'Effectuer le d�ploiement de serveurs intranet',
	'Des attitudes',
	'11111'
),
( --G�n�ral commun
	'4EF1',
	null,
	'Expliquer les repr�sentations du monde contenues dans des textes litt�raires d��poques et de genres vari�s',
	'Des attitudes',
	'11111'
),
( --G�n�ral propre
	'4SAP',
	null,
	'Communiquer en anglais de fa�on simple en utilisant des formes d�expression d�usage courant li�es au champ d��tudes de l��l�ve',
	'Des attitudes',
	'11111'
)
GO


--�l�ments de comp�tence
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
	'Pr�parer l�ordinateur',
	'11111'
),
(
	'00Q1',
	1,
	'Installer le syst�me d�exploitation',
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
	'Effectuer des t�ches de gestion du syst�me d�exploitation',
	'11111'
),
--00SJ
(
	'00SJ',
	0,
	'Analyser le projet de d�ploiement',
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
	'Proc�der au renforcement de la s�curit�',
	'11111'
),
(
	'00SJ',
	4,
	'Participer � la mise en service des serveurs intranet',
	'11111'
),
(
	'00SJ',
	5,
	'R�diger la documentation',
	'11111'
),
--4EF1
(
	'4EF1',
	0,
	'Reconna�tre le traitement d�un th�me dans un texte',
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
	'D�gager les rapports entre le r�el, le langage et l�imaginaire',
	'11111'
),
(
	'4EF1',
	3,
	'�laborer un plan de dissertation',
	'11111'
),
(
	'4EF1',
	4,
	'R�diger une dissertation explicative',
	'11111'
),
(
	'4EF1',
	5,
	'R�viser et corriger le texte',
	'11111'
),
--4SAP
(
	'4SAP',
	0,
	'D�gager le sens d�un message oral authentique li� � son champ d��tudes',
	'11111'
),
(
	'4SAP',
	1,
	'D�gager le sens d�un texte authentique li� � son champ d��tudes',
	'11111'
),
(
	'4SAP',
	2,
	'Communiquer un bref message oral li� � son champ d��tudes',
	'11111'
),
(
	'4SAP',
	3,
	'R�diger et r�viser un court texte li� � son champ d��tudes',
	'11111'
)
GO


--Contextes de r�alisation
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
	'Pour diff�rents syst�mes d�exploitation.',
	'22222'
),
(
	'00Q1',
	1,
	'� partir d�une demande.',
	'22222'
),
(
	'00Q1',
	2,
	'� l�aide d�ordinateurs, de p�riph�riques, de composants internes amovibles, etc.',
	'22222'
),
(
	'00Q1',
	3,
	'� l�aide de la documentation technique.',
	'22222'
),
(
	'00Q1',
	4,
	'� partir d�une demande.',
	'22222'
),
--00SJ
(
	'00SJ',
	0,
	'Pour des serveurs intranet de diff�rents types : physiques, virtualis�s, redondants, distribu�s, etc.',
	'22222'
),
(
	'00SJ',
	1,
	'Pour diff�rents services : authentification, annuaire, impression, partage de fichiers, t�l�phonie, DHCP, etc.',
	'22222'
)
--4EF1
--(Aucun)
--4SAP
--(Aucun)
GO


--Crit�res de performance
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
	'Interpr�tation juste de la demande.',
	'11111'
),
(
	'00Q1',
	0,
	1,
	'Interpr�tation juste des sp�cifications de l��quipement informatique.',
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
	'Raccordement correct des p�riph�riques.',
	'11111'
),
(
	'00Q1',
	0,
	4,
	'Positionnement ergonomique de l�ordinateur et de ses p�riph�riques.',
	'11111'
),
(
	'00Q1',
	1,
	0,
	'Utilisation appropri�e des utilitaires de pr�paration des syst�mes de fichiers.',
	'11111'
),
(
	'00Q1',
	2,
	0,
	'Application correcte de la proc�dure d�installation des applications et des modules d�extension.',
	'11111'
),
(
	'00Q1',
	3,
	0,
	'Organisation fonctionnelle de la structure des fichiers et des r�pertoires.',
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
	'Positionnement et fixation des serveurs et des p�riph�riques conformes aux plans.',
	'11111'
),
(
	'4EF1',
	0,
	0,
	'Relev� des proc�d�s stylistiques et litt�raires utilis�s pour le d�veloppement du th�me.',
	'11111'
),
(
	'4SAP',
	0,
	0,
	'Reconnaissance du sens g�n�ral et des id�es essentielles du message.',
	'11111'
)

INSERT INTO TCRSTMPLT
(
	CRS_ID,
	VSN_CDTTM, --Numero de version
	PGM_ID,
	CRS_TITLE,
	UNITS,
	CRS_DESC,
	CRS_INTENT,
	DPTMNT_APPRV_DT,
	CMTE_APPRV_DT,
	BOARD_APPRV_DT,
	TRK_UID
)
VALUES
(
	'420-1G1-HU',
	GETDATE(),
	'420.B0',
	'Ordinateur et r�seaux de PME',
	3.33,
	'Ce cours permet � l��tudiante ou l��tudiant d�apprendre le fonctionnement d�une station de travail du point de vue mat�riel et logiciel. Il apprend aussi les r�gles de base de la s�curit�, l�utilisation de la virtualisation ainsi que l�interconnexion des �quipements.',
	'L��tudiant sait installer efficacement un ordinateur, tant du point de vue mat�riel que logiciel, en fonction de la demande d�un client et en suivant la proc�dure �tablie par l�entreprise.  Il se r�f�re � la documentation pertinente et recherche les derni�res versions des pilotes. Il peut relier l�ordinateur au r�seau de l�entreprise.  Il peut installer et configurer plusieurs syst�mes d�exploitation et les applications pour plusieurs utilisateurs, pour l�archivage et la sauvegarde des donn�es.  Il g�re toutes ses interventions � l�aide des applications appropri�es.',
	'2019-02-01',
	'2019-03-30',
	'2019-04-05',
	'11111'
)