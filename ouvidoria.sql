-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.6.17 - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para ouvidoria
CREATE DATABASE IF NOT EXISTS `ouvidoria` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ouvidoria`;

-- Copiando estrutura para tabela sisvendas.caixa
CREATE TABLE IF NOT EXISTS `caixa` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `status` int(1) DEFAULT '0',
  `dataAbertura` date DEFAULT NULL,
  `dataFechamento` date DEFAULT NULL,
  `valorInicial` decimal(9,2) DEFAULT '0.00',
  `valorFinal` decimal(9,2) DEFAULT '0.00',
  `valorCredito` decimal(9,2) DEFAULT '0.00',
  `valorDebito` decimal(9,2) DEFAULT '0.00',
  `valorDinheiro` decimal(9,2) DEFAULT '0.00',
  `valorCheque` decimal(9,2) DEFAULT '0.00',
  `valorBoleto` decimal(9,2) DEFAULT '0.00',
  `receitas` decimal(9,2) DEFAULT '0.00',
  `despesas` decimal(9,2) DEFAULT '0.00',
  `retiradas` decimal(9,2) DEFAULT '0.00',
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_caixa_usuarios` (`id_usuario`),
  CONSTRAINT `FK_caixa_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.caixa: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `caixa` DISABLE KEYS */;
INSERT INTO `caixa` (`id`, `status`, `dataAbertura`, `dataFechamento`, `valorInicial`, `valorFinal`, `valorCredito`, `valorDebito`, `valorDinheiro`, `valorCheque`, `valorBoleto`, `receitas`, `despesas`, `retiradas`, `id_usuario`) VALUES
	(1, 1, '2016-11-27', NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1);
/*!40000 ALTER TABLE `caixa` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.caixa_retiradas
CREATE TABLE IF NOT EXISTS `caixa_retiradas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` date DEFAULT NULL,
  `valor` decimal(9,2) DEFAULT NULL,
  `obs` varchar(200) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `id_caixa` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_caixa_retiradas_usuarios` (`id_usuario`),
  KEY `FK_caixa_retiradas_caixa` (`id_caixa`),
  CONSTRAINT `FK_caixa_retiradas_caixa` FOREIGN KEY (`id_caixa`) REFERENCES `caixa` (`id`),
  CONSTRAINT `FK_caixa_retiradas_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.caixa_retiradas: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `caixa_retiradas` DISABLE KEYS */;
/*!40000 ALTER TABLE `caixa_retiradas` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cod` int(11) DEFAULT NULL,
  `tipo` varchar(10) DEFAULT NULL,
  `dtnasc` date DEFAULT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  `cpf_cnpj` varchar(20) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `numero` varchar(30) DEFAULT NULL,
  `bairro` varchar(30) DEFAULT NULL,
  `cidade` varchar(30) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `cep` varchar(20) DEFAULT NULL,
  `tel` varchar(20) DEFAULT NULL,
  `cel` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `obs` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cod` (`cod`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.cliente: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`id`, `cod`, `tipo`, `dtnasc`, `descricao`, `cpf_cnpj`, `endereco`, `numero`, `bairro`, `cidade`, `uf`, `cep`, `tel`, `cel`, `email`, `obs`) VALUES
	(1, 55566, 'FISICA', '1984-04-05', 'CONSUMIDOR', '22.222.222/2229-98', 'RUA 5', '2153', 'SOMAR', 'PERUIBE', 'SP', '11750-000', '13 3456-1601', '13 9,9783-0079', 'gui@hotmail.com', 'TESTE'),
	(2, 1, 'FISICA', '1984-04-03', 'GUILHERME HENRIQUE DOS SANTOS', '   .   .   -', '', '', '', 'PERUIBE', 'SP', '11750-000', '13 9978-3007', '    ,    -', '', 'AMOR');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.logs
CREATE TABLE IF NOT EXISTS `logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `action` varchar(200) DEFAULT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_logs_usuarios` (`id_usuario`),
  CONSTRAINT `FK_logs_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.logs: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `logs` DISABLE KEYS */;
INSERT INTO `logs` (`id`, `action`, `time`, `id_usuario`) VALUES
	(1, 'USUÁRIO CADASTRADO | NOME: DALVA', '2017-12-17 18:58:35', 1),
	(2, 'USUÁRIO CADASTRADO | NOME: DALVA', '2017-12-17 18:58:41', 1),
	(3, 'USUÁRIO CADASTRADO | NOME: NENA', '2017-12-17 18:58:54', 1),
	(4, 'USUÁRIO CADASTRADO | NOME: EDNA', '2017-12-17 18:59:26', 1),
	(5, 'USUÁRIO ATUALIZADO | NOME: NENA', '2017-12-17 18:59:31', 1),
	(6, 'USUÁRIO CADASTRADO | NOME: MARCIA', '2017-12-17 18:59:52', 1);
/*!40000 ALTER TABLE `logs` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.pedidos
CREATE TABLE IF NOT EXISTS `pedidos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `qtd` int(10) DEFAULT NULL,
  `subtotal` decimal(9,2) DEFAULT NULL,
  `id_produto` int(11) DEFAULT NULL,
  `id_venda` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_pedidos_produtos` (`id_produto`),
  KEY `FK_pedidos_venda` (`id_venda`),
  CONSTRAINT `FK_pedidos_produtos` FOREIGN KEY (`id_produto`) REFERENCES `produtos` (`id`),
  CONSTRAINT `FK_pedidos_venda` FOREIGN KEY (`id_venda`) REFERENCES `venda` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.pedidos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.pgto
CREATE TABLE IF NOT EXISTS `pgto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `valor` decimal(9,2) DEFAULT NULL,
  `nparcelas` int(11) DEFAULT '1',
  `valorparcela` decimal(9,2) DEFAULT NULL,
  `id_tipo` int(11) DEFAULT NULL,
  `id_venda` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_pgto_pgto_tipo` (`id_tipo`),
  KEY `FK_pgto_venda` (`id_venda`),
  CONSTRAINT `FK_pgto_pgto_tipo` FOREIGN KEY (`id_tipo`) REFERENCES `pgto_tipo` (`id`),
  CONSTRAINT `FK_pgto_venda` FOREIGN KEY (`id_venda`) REFERENCES `venda` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.pgto: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `pgto` DISABLE KEYS */;
/*!40000 ALTER TABLE `pgto` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.pgto_tipo
CREATE TABLE IF NOT EXISTS `pgto_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.pgto_tipo: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `pgto_tipo` DISABLE KEYS */;
INSERT INTO `pgto_tipo` (`id`, `descricao`) VALUES
	(1, 'DINHEIRO'),
	(2, 'CRÉDITO'),
	(3, 'DÉBITO'),
	(4, 'BOLETO'),
	(5, 'ACRESCIMO'),
	(6, 'DESCONTO'),
	(7, 'CHEQUE');
/*!40000 ALTER TABLE `pgto_tipo` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.produtos
CREATE TABLE IF NOT EXISTS `produtos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cod` varchar(50) DEFAULT NULL,
  `descricao` varchar(50) DEFAULT NULL,
  `valor` decimal(9,2) DEFAULT NULL,
  `estoque` int(11) DEFAULT NULL,
  `id_tipo` int(11) DEFAULT NULL,
  `compra` varchar(50) DEFAULT NULL,
  `loja` varchar(100) DEFAULT NULL,
  `tamanho` varchar(3) DEFAULT NULL,
  `custo` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cod` (`cod`,`tamanho`),
  KEY `FK_produtos_produtos_tipo` (`id_tipo`),
  CONSTRAINT `FK_produtos_produtos_tipo` FOREIGN KEY (`id_tipo`) REFERENCES `produtos_tipo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.produtos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `produtos` DISABLE KEYS */;
INSERT INTO `produtos` (`id`, `cod`, `descricao`, `valor`, `estoque`, `id_tipo`, `compra`, `loja`, `tamanho`, `custo`) VALUES
	(1, '9050001', 'BERMUDA C/ILHOS, NUDE', 48.00, 1, 2, '14', 'ITEM 1', 'M', 29.90);
/*!40000 ALTER TABLE `produtos` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.produtos_tipo
CREATE TABLE IF NOT EXISTS `produtos_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.produtos_tipo: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `produtos_tipo` DISABLE KEYS */;
INSERT INTO `produtos_tipo` (`id`, `descricao`) VALUES
	(1, 'PRODUTO'),
	(2, 'BERMUDA');
/*!40000 ALTER TABLE `produtos_tipo` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.produto_usuario
CREATE TABLE IF NOT EXISTS `produto_usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_produto` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `data` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_produto` (`id_produto`,`id_usuario`),
  KEY `FK_produto_usuario_usuarios` (`id_usuario`),
  CONSTRAINT `FK_produto_usuario_produtos` FOREIGN KEY (`id_produto`) REFERENCES `produtos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_produto_usuario_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.produto_usuario: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `produto_usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `produto_usuario` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `ativo` int(1) DEFAULT NULL,
  `level` int(1) DEFAULT '0',
  `cadCliente` int(1) DEFAULT '0',
  `cadProdutos` int(1) DEFAULT '0',
  `vendas` int(1) DEFAULT '0',
  `caixa` int(1) DEFAULT '0',
  `relatorios` int(1) DEFAULT '0',
  `consultacli` int(1) DEFAULT '0',
  `relatoriocaixa` int(1) DEFAULT '0',
  `config` int(1) DEFAULT '0',
  `backup` int(1) DEFAULT '0',
  `consultaprod` int(1) DEFAULT '0',
  `cadUsuario` int(1) DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nome` (`nome`),
  UNIQUE KEY `senha` (`senha`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.usuarios: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`id`, `nome`, `senha`, `ativo`, `level`, `cadCliente`, `cadProdutos`, `vendas`, `caixa`, `relatorios`, `consultacli`, `relatoriocaixa`, `config`, `backup`, `consultaprod`, `cadUsuario`) VALUES
	(1, 'VANESSA', '1', 1, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
	(3, 'DALVA', 'DALVA', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(4, 'NENA', 'NENA', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(5, 'EDNA', 'EDNA', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(6, 'MARCIA', 'MARCIA', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

-- Copiando estrutura para tabela sisvendas.venda
CREATE TABLE IF NOT EXISTS `venda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cod` varchar(50) DEFAULT NULL,
  `status` int(1) DEFAULT '0',
  `data` date DEFAULT NULL,
  `total` decimal(9,2) DEFAULT NULL,
  `acrescimos` decimal(9,2) DEFAULT NULL,
  `descontos` decimal(9,2) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `id_caixa` int(11) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cod` (`cod`),
  KEY `FK_venda_cliente` (`id_cliente`),
  KEY `FK_venda_caixa` (`id_caixa`),
  KEY `FK_venda_usuarios` (`id_usuario`),
  CONSTRAINT `FK_venda_caixa` FOREIGN KEY (`id_caixa`) REFERENCES `caixa` (`id`),
  CONSTRAINT `FK_venda_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`),
  CONSTRAINT `FK_venda_usuarios` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela sisvendas.venda: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;

-- Copiando estrutura para view sisvendas.vwestoque
-- Criando tabela temporária para evitar erros de dependência de VIEW
CREATE TABLE `vwestoque` (
	`loja` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`compra` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`estoque` INT(11) NULL,
	`descricao` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`cod` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`tamanho` VARCHAR(3) NULL COLLATE 'utf8_general_ci',
	`custo` DECIMAL(9,2) NULL,
	`valor` DECIMAL(9,2) NULL
) ENGINE=MyISAM;

-- Copiando estrutura para view sisvendas.vwretiradas
-- Criando tabela temporária para evitar erros de dependência de VIEW
CREATE TABLE `vwretiradas` (
	`id` INT(11) NOT NULL,
	`data` DATE NULL,
	`valor` DECIMAL(9,2) NULL,
	`obs` VARCHAR(200) NULL COLLATE 'utf8_general_ci',
	`nome` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`id_caixa` INT(11) NULL
) ENGINE=MyISAM;

-- Copiando estrutura para view sisvendas.vwvendas
-- Criando tabela temporária para evitar erros de dependência de VIEW
CREATE TABLE `vwvendas` (
	`id` INT(11) NOT NULL,
	`CodV` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`status` INT(1) NULL,
	`data` DATE NULL,
	`acrescimos` DECIMAL(9,2) NULL,
	`descontos` DECIMAL(9,2) NULL,
	`total` DECIMAL(9,2) NULL,
	`Loja` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`compra` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`idVendedor` INT(11) NOT NULL,
	`Usuario` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`codP` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`Produto` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`tamanho` VARCHAR(3) NULL COLLATE 'utf8_general_ci',
	`Custo` DECIMAL(9,2) NULL,
	`Preco` DECIMAL(9,2) NULL,
	`qtd` INT(10) NULL,
	`subtotal` DECIMAL(9,2) NULL,
	`idPgto` INT(11) NOT NULL,
	`Pgto` VARCHAR(50) NULL COLLATE 'utf8_general_ci',
	`valor` DECIMAL(9,2) NULL,
	`nparcelas` INT(11) NULL,
	`valorparcela` DECIMAL(9,2) NULL,
	`idCli` INT(11) NULL,
	`codC` INT(11) NULL,
	`dtnascCli` DATE NULL,
	`Nome` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`cpf_cnpj` VARCHAR(20) NULL COLLATE 'utf8_general_ci',
	`endereco` VARCHAR(100) NULL COLLATE 'utf8_general_ci',
	`numero` VARCHAR(30) NULL COLLATE 'utf8_general_ci',
	`bairro` VARCHAR(30) NULL COLLATE 'utf8_general_ci',
	`cidade` VARCHAR(30) NULL COLLATE 'utf8_general_ci',
	`uf` VARCHAR(2) NULL COLLATE 'utf8_general_ci',
	`tel` VARCHAR(20) NULL COLLATE 'utf8_general_ci',
	`cel` VARCHAR(20) NULL COLLATE 'utf8_general_ci',
	`cep` VARCHAR(20) NULL COLLATE 'utf8_general_ci'
) ENGINE=MyISAM;

-- Copiando estrutura para view sisvendas.vwestoque
-- Removendo tabela temporária e criando a estrutura VIEW final
DROP TABLE IF EXISTS `vwestoque`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` VIEW `vwestoque` AS SELECT loja,compra,estoque,descricao,cod,tamanho,custo,valor FROM produtos ;

-- Copiando estrutura para view sisvendas.vwretiradas
-- Removendo tabela temporária e criando a estrutura VIEW final
DROP TABLE IF EXISTS `vwretiradas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` VIEW `vwretiradas` AS select `caixa_retiradas`.`id` AS `id`,`caixa_retiradas`.`data` AS `data`,`caixa_retiradas`.`valor` AS `valor`,`caixa_retiradas`.`obs` AS `obs`,`usuarios`.`nome` AS `nome`,`caixa_retiradas`.`id_caixa` AS `id_caixa` from (`caixa_retiradas` join `usuarios` on((`caixa_retiradas`.`id_usuario` = `usuarios`.`id`))) ;

-- Copiando estrutura para view sisvendas.vwvendas
-- Removendo tabela temporária e criando a estrutura VIEW final
DROP TABLE IF EXISTS `vwvendas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` VIEW `vwvendas` AS select `venda`.`id` AS `id`,`venda`.`cod` AS `CodV`,`venda`.`status` AS `status`,`venda`.`data` AS `data`,`venda`.`acrescimos` 
AS `acrescimos`,`venda`.`descontos` AS `descontos`,`venda`.`total` AS `total`,produtos.loja as Loja,produtos.compra,usuarios.id 
AS idVendedor,`usuarios`.`nome` AS `Usuario`,`produtos`.`cod` AS `codP`,`produtos`.`descricao` AS `Produto`,produtos.tamanho,produtos.custo 
AS Custo,`produtos`.`valor` AS `Preco`,`pedidos`.`qtd` AS `qtd`,`pedidos`.`subtotal` AS `subtotal`,`pgto`.`id` AS `idPgto`,`pgto_tipo`.`descricao` AS `Pgto`,`pgto`.`valor` AS `valor`,`pgto`.`nparcelas` AS `nparcelas`,`pgto`.`valorparcela` AS `valorparcela`,`cliente`.`id` AS `idCli`,`cliente`.`cod` AS `codC`,`cliente`.`dtnasc` AS `dtnascCli`,`cliente`.`descricao` AS `Nome`,`cliente`.`cpf_cnpj` AS `cpf_cnpj`,`cliente`.`endereco` AS `endereco`,`cliente`.`numero` AS `numero`,`cliente`.`bairro` AS `bairro`,`cliente`.`cidade` AS `cidade`,`cliente`.`uf` AS `uf`,`cliente`.`tel` AS `tel`,`cliente`.`cel` AS `cel`,`cliente`.`cep` AS `cep` 
from ((((((`venda` join `pedidos` on((`pedidos`.`id_venda` = `venda`.`id`))) join `produtos` on((`produtos`.`id` = `pedidos`.`id_produto`))) 
join `pgto` on((`pgto`.`id_venda` = `venda`.`id`))) join `pgto_tipo` on((`pgto_tipo`.`id` = `pgto`.`id_tipo`))) 
left join `cliente` on((`cliente`.`id` = `venda`.`id_cliente`))) join `usuarios` on((`usuarios`.`id` = `venda`.`id_usuario`))) ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
