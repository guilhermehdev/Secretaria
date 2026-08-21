Public Class ApacRegistro

    Public Property NumeroApac As String
    Public Property NomePaciente As String
    Public Property DtnascPaciente As Date
    Public Property CPFPaciente As String
    Public Property MaePaciente As String
    Public Property CEPPaciente As String
    Public Property TipoLograPaciente As String
    Public Property LograPaciente As String
    Public Property BairroPaciente As String
    Public Property numeroResPaciente As String
    Public Property complementoPaciente As String
    Public Property TelPaciente As String
    Public Property ProcedimentoPrincipal As String
    Public Property SUSMedicoExecutante As String
    Public Property data As Date
    Public Property competencia As String

    ' ---------- Campos adicionados (antes ficavam de fora do importFromApacs) ----------
    ' Mantidos como String (não Date) nos campos de data porque alguns vêm em branco no
    ' arquivo (ex: DtAltaObito quando motivo de saída = "00") e DateTime.ParseExact
    ' quebraria nesse caso. Convertam pra Date na hora de usar, se precisarem.

    Public Property UF As String
    Public Property CnesExecutante As String           ' CNES da unidade executante (cabeçalho da APAC)
    Public Property DtValidadeFim As String
    Public Property TipoAtendimento As String
    Public Property TipoApac As String
    Public Property SexoPaciente As String
    Public Property NomeMedicoSolicitante As String
    Public Property MotivoSaida As String
    Public Property DtAltaObito As String
    Public Property NomeAutorizador As String
    Public Property CnsPaciente As String
    Public Property CnsAutorizador As String
    Public Property CidCausasAssociadas As String
    Public Property Prontuario As String
    Public Property CnesSolicitante As String
    Public Property DtSolicitacao As String
    Public Property DtAutorizacao As String
    Public Property CodigoEmissor As String
    Public Property CaraterAtendimento As String
    Public Property ApacAnterior As String
    Public Property Raca As String
    Public Property NomeResponsavelPaciente As String
    Public Property Nacionalidade As String
    Public Property Etnia As String
    Public Property Email As String
    Public Property CnsExecutante As String             ' CNS do médico executante de verdade (ver observação sobre SUSMedicoExecutante)
    Public Property Equipe As String
    Public Property SituacaoRua As String
    Public Property FonteOrcamentaria As String
    Public Property EmendasParlamentares As String
    Public Property SemCpf As String

    ' Vêm do registro "06" (CID), não do registro "14" - por isso são
    ' preenchidos depois, quando o importFromApacs encontra a linha "06"
    ' correspondente a este mesmo num_apac.
    Public Property CidPrincipal As String
    Public Property CidSecundario As String

    ' ---------- Campos usados pra GERAR a APAC (addAPAC), não pela importação ----------
    ' Esta classe passou a ser usada também como parâmetro de addAPAC()/saveAPAC()/
    ' atPac() - em vez dessas funções lerem só dos controles da tela, agora também
    ' aceitam um ApacRegistro pronto (montado a partir do banco, por ex. em geração
    ' de lote). Os campos abaixo cobrem o que faltava em relação ao que addAPAC() lê.

    ' IDs já resolvidos no banco - quando informados, pulam a busca/seleção manual
    ' de paciente e endereço (equivalente a já ter clicado no resultado da busca).
    Public Property IdPaciente As Integer?
    Public Property IdEndereco As Integer?

    Public Property Gestor As String
    Public Property DDD As String
    Public Property Telefone As String
    Public Property CboMedico As String ' CBO do médico executante (registro 13 principal)

    ' Procedimentos secundários (registro 13) explícitos - usado principalmente pro
    ' código 0903010011, cuja lista vem de procedimentos_secundarios e não é fixa
    ' feito os outros códigos (que a tela já recria sozinha ao selecionar o principal).
    Public Property ProcedimentosSecundarios As List(Of ApacProcedimentoSecundario)

End Class

''' <summary>
''' Uma linha do registro 13 secundário: código do procedimento, quantidade,
''' descrição (só usada pra exibição na grid) e CBO do profissional que executou.
''' </summary>
Public Class ApacProcedimentoSecundario
    Public Property Codigo As String
    Public Property Quantidade As String
    Public Property Descricao As String
    Public Property Cbo As String
End Class