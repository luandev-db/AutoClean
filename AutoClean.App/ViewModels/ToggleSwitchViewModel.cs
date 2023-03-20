// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoClean.App.ViewModels;
using Microsoft.Win32;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using AutoClean.App.Services;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Mvvm.Services;

namespace AutoClean.App.ViewModels
{
    public partial class ToggleSwitchViewModel : ObservableObject
    {

        public ToggleSwitchViewModel(ISnackbarService snackbarService)
        {
            _snackbarService = snackbarService;
        }
        #region Cortana
        private readonly ISnackbarService _snackbarService;
        private bool _cortanaCommand;
        public bool CortanaCommand
        {
            get { return _cortanaCommand; }
            set
            {
                SetProperty(ref _cortanaCommand, value);
                if (value)
                {
                    CortanaSnackbar();
                }
                else
                {
                    CortanaSnackbar();

                }
            }
        }

        private async Task CortanaSnackbar()
        {

            if (CortanaCommand == true)
            {

                await _snackbarService.ShowAsync("Cortana desativada", "Cortana desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Cortana Ativada", "Cortana é desnecessária e entrou em desuso pela própria Microsoft.", SymbolRegular.Warning24, ControlAppearance.Caution);
            }
        }
        #endregion
        #region Xbox
        private bool _xboxCommand;
        public bool XboxCommand
        {
            get { return _xboxCommand; }
            set
            {
                SetProperty(ref _xboxCommand, value);
                if (value)
                {
                    XboxSnackbar();
                }
                else
                {
                    XboxSnackbar();

                }


            }
        }

        private async Task XboxSnackbar()
        {
            if (XboxCommand == true)
            {
                await _snackbarService.ShowAsync("Xbox DVR desativado", "Xbox desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Xbox DVR Ativado", "Xbox DVR Ativado consome desempenho do Windows em segundo plano, esse recurso são usados para gravar e transmitir jogos.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Energia
        private bool _energiaCommand;
        public bool EnergiaCommand
        {
            get { return _energiaCommand; }
            set
            {
                SetProperty(ref _energiaCommand, value);
                if (value)
                {
                    EnergiaSnackbar();
                }
                else
                {
                    EnergiaSnackbar();

                }


            }
        }

        private async Task EnergiaSnackbar()
        {
            if (EnergiaCommand == true)
            {
                await _snackbarService.ShowAsync("Energia otimizada", "Energia otimizada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Energia não otimizado", "O Windows está em economia de energia.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Modo Jogo
        private bool _modojogoCommand;
        public bool ModoJogoCommand
        {
            get { return _modojogoCommand; }
            set
            {
                SetProperty(ref _modojogoCommand, value);
                if (value)
                {
                    ModoJogoSnackbar();
                }
                else
                {
                    ModoJogoSnackbar();

                }


            }
        }

        private async Task ModoJogoSnackbar()
        {
            if (ModoJogoCommand == true)
            {
                await _snackbarService.ShowAsync("Modo jogo desativado", "Modo jogo desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Modo Jogo ativado", "Modo de jogo afeta o desempenho geral do Windows.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Aero Shake
        private bool _aeroshakeCommand;
        public bool AeroShakeCommand
        {
            get { return _modojogoCommand; }
            set
            {
                SetProperty(ref _modojogoCommand, value);
                if (value)
                {
                    AeroShakeSnackbar();
                }
                else
                {
                    AeroShakeSnackbar();

                }


            }
        }

        private async Task AeroShakeSnackbar()
        {
            if (AeroShakeCommand == true)
            {
                await _snackbarService.ShowAsync("Aero Shake desativado", "Aero Shake desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Aero Shake Padrão", "Gestos não necessários nas janelas do Windows.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Tela Cheia
        private bool _telacheiaCommand;
        public bool TelaCheiaCommand
        {
            get { return _telacheiaCommand; }
            set
            {
                SetProperty(ref _telacheiaCommand, value);
                if (value)
                {
                    TelaCheiaSnackbar();
                }
                else
                {
                    TelaCheiaSnackbar();

                }


            }
        }

        private async Task TelaCheiaSnackbar()
        {
            if (TelaCheiaCommand == true)
            {
                await _snackbarService.ShowAsync("Tela cheia otimizada", "Tela cheia otimizada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Tela cheia não otimizada", "Serviços em segundo plano podem prejudicar o desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Smart Screen
        private bool _smartscreenCommand;
        public bool SmartScreenCommand
        {
            get { return _smartscreenCommand; }
            set
            {
                SetProperty(ref _smartscreenCommand, value);
                if (value)
                {
                    SmartScreenSnackbar();
                }
                else
                {
                    SmartScreenSnackbar();

                }


            }
        }

        private async Task SmartScreenSnackbar()
        {
            if (SmartScreenCommand == true)
            {
                await _snackbarService.ShowAsync("Smart Screen desativado", "Smart Screen desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Smart Screen ativado", "O Smart Screen é uma proteção obsoleta e não necessária para ganho de desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Consumo de energia
        private bool _consumoEnergiaCommand;
        public bool ConsumoEnergiaCommand
        {
            get { return _consumoEnergiaCommand; }
            set
            {
                SetProperty(ref _consumoEnergiaCommand, value);
                if (value)
                {
                    ConsumoEnergiaSnackbar();
                }
                else
                {
                    ConsumoEnergiaSnackbar();

                }


            }
        }

        private async Task ConsumoEnergiaSnackbar()
        {
            if (ConsumoEnergiaCommand == true)
            {
                await _snackbarService.ShowAsync("Consumo de energia otimizado", "Consumo de energia otimizado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Consumo de energia não otimizado", "O Windows por padrão não vem configurado para o máximo de desempenho de energia.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }
        }
        #endregion
        #region Fax
        private bool _faxCommand;
        public bool FaxCommand
        {
            get { return _faxCommand; }
            set
            {
                SetProperty(ref _faxCommand, value);
                if (value)
                {
                    FaxSnackbar();
                }
                else
                {
                    FaxSnackbar();

                }


            }
        }

        private async Task FaxSnackbar()
        {
            if (FaxCommand == true)
            {
                await _snackbarService.ShowAsync("Fax desativado", "Fax desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Fax ativado", "Serviços em segundo plano podem prejudicar o desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Telemetria
        private bool _telemetriaCommand;
        public bool TelemetriaCommand
        {
            get { return _telemetriaCommand; }
            set
            {
                SetProperty(ref _telemetriaCommand, value);
                if (value)
                {
                    TelemetriaSnackbar();
                }
                else
                {
                    TelemetriaSnackbar();

                }


            }
        }

        private async Task TelemetriaSnackbar()
        {
            if (TelemetriaCommand == true)
            {
                await _snackbarService.ShowAsync("Telemetria desativada", "Telemetria desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Telemetria ativada", "Telemetria é usada para Microsoft recolher dados do funcionamento do seu Windows.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Windows Update
        private bool _windowsupdateCommand;
        public bool WindowsUpdateCommand
        {
            get { return _windowsupdateCommand; }
            set
            {
                SetProperty(ref _windowsupdateCommand, value);
                if (value)
                {
                    WindowsUpdateSnackbar();
                }
                else
                {
                    WindowsUpdateSnackbar();

                }


            }
        }

        private async Task WindowsUpdateSnackbar()
        {
            if (WindowsUpdateCommand == true)
            {
                await _snackbarService.ShowAsync("Windows Update desativado", "Windows Update desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Windows Update ativada", "O Windows Update pode atualizar em ocasiões inesperadas e consumir desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Animações
        private bool _animacoesCommand;
        public bool AnimacoesCommand
        {
            get { return _animacoesCommand; }
            set
            {
                SetProperty(ref _animacoesCommand, value);
                if (value)
                {
                    AnimacoesSnackbar();
                }
                else
                {
                    AnimacoesSnackbar();

                }


            }
        }

        private async Task AnimacoesSnackbar()
        {
            if (AnimacoesCommand == true)
            {
                await _snackbarService.ShowAsync("Animações desativadas", "Animações desativadas com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Animações ativadas", "Animações do Windows pode deixar o sistema lento em máquinas antigas.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Superfetch
        private bool _superfetchCommand;
        public bool SuperfetchCommand
        {
            get { return _superfetchCommand; }
            set
            {
                SetProperty(ref _superfetchCommand, value);
                if (value)
                {
                    SuperfetchSnackbar();
                }
                else
                {
                    SuperfetchSnackbar();

                }


            }
        }

        private async Task SuperfetchSnackbar()
        {
            if (SuperfetchCommand == true)
            {
                await _snackbarService.ShowAsync("Superfetch desativado", "Superfetch desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Superfetch ativado", "Tipo de alocação de memória não eficaz (caso tenha memoria RAM suficiente).", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region SysMain
        private bool _sysMainCommand;
        public bool SysMainCommand
        {
            get { return _sysMainCommand; }
            set
            {
                SetProperty(ref _sysMainCommand, value);
                if (value)
                {
                    SysMainSnackbar();
                }
                else
                {
                    SysMainSnackbar();

                }


            }
        }

        private async Task SysMainSnackbar()
        {
            if (SysMainCommand == true)
            {
                await _snackbarService.ShowAsync("SysMain desativado", "SysMain desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("SysMain ativado", "Sysmain é o serviço de otimização de desempenho do Windows. Desative se seu PC estiver lento ou travando.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Impressão
        private bool _impressaoCommand;
        public bool ImpressaoCommand
        {
            get { return _impressaoCommand; }
            set
            {
                SetProperty(ref _impressaoCommand, value);
                if (value)
                {
                    ImpressaoSnackbar();
                }
                else
                {
                    ImpressaoSnackbar();

                }


            }
        }

        private async Task ImpressaoSnackbar()
        {
            if (ImpressaoCommand == true)
            {
                await _snackbarService.ShowAsync("Impressão desativada", "Impressão desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Impressão ativada", "Desativar impressão no Windows pode economizar recursos.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Windows defender
        private bool _windowsDefenderCommand;
        public bool WindowsDefenderCommand
        {
            get { return _windowsDefenderCommand; }
            set
            {
                SetProperty(ref _windowsDefenderCommand, value);
                if (value)
                {
                    WindowsDefenderCommandSnackbar();
                }
                else
                {
                    WindowsDefenderCommandSnackbar();

                }


            }
        }

        private async Task WindowsDefenderCommandSnackbar()
        {
            if (WindowsDefenderCommand == true)
            {
                await _snackbarService.ShowAsync("Windows defender desativado", "Windows defender desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Windows defender ativado", "Proteção contra vírus e malware: Ativado pode influenciar no desempenho em máquinas antigas.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Compactação
        private bool _compactacaoCommand;
        public bool CompactacaoCommand
        {
            get { return _compactacaoCommand; }
            set
            {
                SetProperty(ref _compactacaoCommand, value);
                if (value)
                {
                    CompactacaoSnackbar();
                }
                else
                {
                    CompactacaoSnackbar();

                }


            }
        }

        private async Task CompactacaoSnackbar()
        {
            if (CompactacaoCommand == true)
            {
                await _snackbarService.ShowAsync("Compactação desativada", "Compactação desativada com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Compactação ativada", "Ativar compactação do Windows: Consome mais espaço e uso de CPU.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Prefetch
        private bool _prefetchCommand;
        public bool PrefetchCommand
        {
            get { return _prefetchCommand; }
            set
            {
                SetProperty(ref _prefetchCommand, value);
                if (value)
                {
                    PrefetchSnackbar();
                }
                else
                {
                    PrefetchSnackbar();

                }


            }
        }

        private async Task PrefetchSnackbar()
        {
            if (PrefetchCommand == true)
            {
                await _snackbarService.ShowAsync("Prefetch desativado", "Prefetch desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Prefetch ativado", "Ativar Prefetch pode prejudicar o desempenho em HDs lentos.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Transparência
        private bool _transparenciaCommand;
        public bool TransparenciaCommand
        {
            get { return _transparenciaCommand; }
            set
            {
                SetProperty(ref _transparenciaCommand, value);
                if (value)
                {
                    TransparenciaSnackbar();
                }
                else
                {
                    TransparenciaSnackbar();

                }


            }
        }

        private async Task TransparenciaSnackbar()
        {
            if (TransparenciaCommand == true)
            {
                await _snackbarService.ShowAsync("Transparência desativado", "Transparência desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Transparência ativado", "Ativar transparência do Windows aumenta o consumo da placa de video.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Menu iniciar
        private bool _menuiniciarCommand;
        public bool MenuIniciarCommand
        {
            get { return _menuiniciarCommand; }
            set
            {
                SetProperty(ref _menuiniciarCommand, value);
                if (value)
                {
                    MenuIniciarSnackbar();
                }
                else
                {
                    MenuIniciarSnackbar();

                }


            }
        }

        private async Task MenuIniciarSnackbar()
        {
            if (MenuIniciarCommand == true)
            {
                await _snackbarService.ShowAsync("Menu iniciar otimizado", "Menu iniciar otimizado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Menu iniciar não otimizado", "Showdelay é atraso do menu iniciar do Windows. Desative para melhor desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Recentes
        private bool _recentesCommand;
        public bool RecentesCommand
        {
            get { return _recentesCommand; }
            set
            {
                SetProperty(ref _recentesCommand, value);
                if (value)
                {
                    RecentesSnackbar();
                }
                else
                {
                    RecentesSnackbar();

                }


            }
        }

        private async Task RecentesSnackbar()
        {
            if (RecentesCommand == true)
            {
                await _snackbarService.ShowAsync("Recentes desativado", "Recentes desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Recentes ativado", "Serviços em segundo plano podem prejudicar o desempenho.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Paginação
        private bool _paginacaoCommand;
        public bool PaginacaoCommand
        {
            get { return _paginacaoCommand; }
            set
            {
                SetProperty(ref _paginacaoCommand, value);
                if (value)
                {
                    PaginacaoSnackbar();
                }
                else
                {
                    PaginacaoSnackbar();

                }


            }
        }

        private async Task PaginacaoSnackbar()
        {
            if (PaginacaoCommand == true)
            {
                await _snackbarService.ShowAsync("Paginação desativada", "Paginação desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Paginação ativada", "Ativar paginação no Windows pode prejudicar em computadores com 8GB ou superior.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Bate papo
        private bool _batepapoCommand;
        public bool BatePapoCommand
        {
            get { return _batepapoCommand; }
            set
            {
                SetProperty(ref _batepapoCommand, value);
                if (value)
                {
                    BatePapoSnackbar();
                }
                else
                {
                    BatePapoSnackbar();

                }


            }
        }

        private async Task BatePapoSnackbar()
        {
            if (BatePapoCommand == true)
            {
                await _snackbarService.ShowAsync("Bate papo desativado", "Bate papo desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Bate papo ativado", "Uma integração desnecessária do Windows 11 com o Microsoft Teams.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Restauração
        private bool _restaucaraoCommand;
        public bool RestauracaoCommand
        {
            get { return _restaucaraoCommand; }
            set
            {
                SetProperty(ref _restaucaraoCommand, value);
                if (value)
                {
                    RestauracaoSnackbar();
                }
                else
                {
                    RestauracaoSnackbar();

                }


            }
        }

        private async Task RestauracaoSnackbar()
        {
            if (RestauracaoCommand == true)
            {
                await _snackbarService.ShowAsync("Restauração desativado", "Restauração desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Restauração ativado", "Desativar ponto de restauração pode economizar espaço em disco.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region One Drive
        private bool _onedriveCommand;
        public bool OneDriveCommand
        {
            get { return _onedriveCommand; }
            set
            {
                SetProperty(ref _onedriveCommand, value);
                if (value)
                {
                    OneDriveSnackbar();
                }
                else
                {
                    OneDriveSnackbar();

                }


            }
        }

        private async Task OneDriveSnackbar()
        {
            if (OneDriveCommand == true)
            {
                await _snackbarService.ShowAsync("One Drive desativado", "One Drive desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("One Drive ativado", "One Drive consome recursos em tempo real e pode afetar o desempenho do Windows.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Pesquisa
        private bool _PesquisaCommand;
        public bool PesquisaCommand
        {
            get { return _PesquisaCommand; }
            set
            {
                SetProperty(ref _PesquisaCommand, value);
                if (value)
                {
                    PesquisaSnackbar();
                }
                else
                {
                    PesquisaSnackbar();

                }


            }
        }

        private async Task PesquisaSnackbar()
        {
            if (PesquisaCommand == true)
            {
                await _snackbarService.ShowAsync("Pesquisa desativado", "Pesquisa desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Pesquisa ativado", "Desativar a pesquisa pode melhorar o desempenho do sistema operacional, pois reduz o uso de recursos de processamento e armazenamento.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Desfragmentação
        private bool _desfragmentacaoCommand;
        public bool DesfragmentacaoCommand
        {
            get { return _desfragmentacaoCommand; }
            set
            {
                SetProperty(ref _desfragmentacaoCommand, value);
                if (value)
                {
                    DesfragmentacaoSnackbar();
                }
                else
                {
                    DesfragmentacaoSnackbar();

                }


            }
        }

        private async Task DesfragmentacaoSnackbar()
        {
            if (DesfragmentacaoCommand == true)
            {
                await _snackbarService.ShowAsync("Desfragmentação desativado", "Desfragmentação desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Desfragmentação ativado", "Ativar a Desfragmentação do Windows não é mais necessário atualmente e pode consumir recursos desnecessários.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
        #region Notificação
        private bool _notificacaoCommand;
        public bool NotificacaoCommand
        {
            get { return _notificacaoCommand; }
            set
            {
                SetProperty(ref _notificacaoCommand, value);
                if (value)
                {
                    NotificacaoSnackbar();
                }
                else
                {
                    NotificacaoSnackbar();

                }


            }
        }

        private async Task NotificacaoSnackbar()
        {
            if (NotificacaoCommand == true)
            {
                await _snackbarService.ShowAsync("Notificação desativado", "Notificação desativado com sucesso...", SymbolRegular.WrenchScrewdriver20, ControlAppearance.Primary);
            }
            else
            {
                await _snackbarService.ShowAsync("Notificação ativado", "Desativar as notificações do Windows pode melhorar a performance do sistema ao reduzir o consumo de recursos de processamento e memória.", SymbolRegular.Warning24, ControlAppearance.Danger);
            }

        }
        #endregion
    }

}
