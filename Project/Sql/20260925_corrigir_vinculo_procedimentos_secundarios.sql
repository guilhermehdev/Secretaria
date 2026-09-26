-- Corrige o escopo de unicidade dos procedimentos secundários.
--
-- A chave antiga usava somente paciente + médico + data + procedimento.
-- Assim, o mesmo paciente atendido no mesmo dia pelo mesmo médico em duas
-- APACs diferentes era tratado como duplicado. O número da APAC é o vínculo
-- correto do procedimento secundário.
--
-- Faça um backup antes de executar em produção.

-- Diagnóstico: se retornar linhas, há mais de um registro do mesmo código
-- dentro da mesma APAC e eles precisam ser revisados antes do ALTER TABLE.
SELECT
    num_apac,
    id_paciente,
    medico_solicitante,
    data,
    cod_proced_secundario,
    COUNT(*) AS quantidade
FROM procedimentos_secundarios
GROUP BY num_apac, id_paciente, medico_solicitante, data, cod_proced_secundario
HAVING COUNT(*) > 1;

-- O índice antigo também era usado para sustentar a FK do paciente.
-- Crie um índice simples antes de removê-lo.
ALTER TABLE procedimentos_secundarios
    ADD INDEX idx_procedimentos_secundarios_paciente (id_paciente);

ALTER TABLE procedimentos_secundarios
    DROP INDEX id_paciente,
    ADD UNIQUE KEY uk_procedimentos_secundarios_apac_codigo
        (num_apac, id_paciente, medico_solicitante, data, cod_proced_secundario);
