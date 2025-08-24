# 🎮 ODS Clicker  
*"Construindo parcerias de forma divertida e interativa"*  

---

## 📌 Descrição Resumida  
ODS Clicker é um jogo **clicker educativo** desenvolvido na Unity como parte do **Projeto Integrador em Programação App** (5° semestre de ADS, professor Romes Heriberto).  
O jogo tem como objetivo conscientizar sobre a importância das **parcerias globais** para o desenvolvimento sustentável, de forma acessível, lúdica e interativa.  

👉 O APK do jogo estará disponível na pasta **`/builds`** deste repositório.  

---

## 🎯 Objetivos  
- Desenvolver uma aplicação lúdica que estimule a reflexão sobre os **Objetivos de Desenvolvimento Sustentável (ODS)**.  
- Promover o aprendizado por meio da gamificação.  
- Entregar um protótipo funcional em Unity, com jogabilidade fluida e interface acessível.  

---

## 🌍 Relevância e Inovação  
O projeto se destaca por **transformar conceitos acadêmicos e sociais em uma experiência de jogo simples**, intuitiva e envolvente.  
Em vez de apenas transmitir informação, ODS Clicker **gamifica o aprendizado**, incentivando o usuário a entender como parcerias entre ONGs, governos e empresas são fundamentais para o progresso coletivo.  

---

## 🏆 Conexão com os ODS da ONU  
O ODS Clicker está diretamente relacionado ao **ODS 17 – Parcerias e meios de implementação**, pois evidencia o papel da cooperação entre diferentes setores.  
Além disso, o projeto se conecta indiretamente a outros ODS, como:  
- **ODS 4 – Educação de Qualidade**, por sua função educativa.  
- **ODS 10 – Redução das Desigualdades**, ao promover a conscientização sobre cooperação global.
- **ODS 17 – Parcerias e Meios de Implementação**, pois o jogo simula a criação de parcerias com ONGs,

---

## 🛠️ Arquitetura e Tecnologias Utilizadas  
- **Motor de Jogo:** Unity  
- **Linguagem:** C#  
- **UI/UX:** Unity UI + TextMeshPro  
- **Controle de versão:** Git + GitHub  
- **Banco de Dados:** PlayerPrefs (salvamento local); possibilidade futura de expansão com NoSQL (Firebase)  

### Estrutura Básica  
- `Botao_script.cs`: lógica de cliques, moedas, compras e efeitos visuais  
- `Botao_Shop.cs`: gerenciamento da loja e animações de interface  
- `soundtrack_script.cs`: controle da trilha sonora  
- `/builds`: diretório onde serão disponibilizados os APKs  

---

## ⚙️ Funcionalidades  
### Essenciais  
- Botão principal para acumular parcerias (moedas).  
- Mapa dinâmico que muda conforme o progresso.  
- Loja representada por um globo terrestre para comprar ONGs e Governos.  
- Atualização em tempo real da UI (valores, textos e custos progressivos).  
- Mensagens visuais de saldo insuficiente.  
- Efeitos de partículas e animações de cliques.  
- Trilha sonora contínua e automática.  

### Futuras (extras)  
- Ranking online de jogadores.  
- Novas entidades para compra (empresas, instituições internacionais etc.).  
- Melhorias de acessibilidade digital (leitores de tela, legendas, modo daltônico).  

---

## ▶️ Como Executar o Projeto  
### Pré-requisitos  
- Sistema operacional: Android (para executar o APK).  
- Para desenvolvimento: Unity 2022+ e Git instalado.  

### Passo a Passo  
1. Clone este repositório:  
   ```bash
   git clone https://github.com/FireGodis/ODS_CLicker
