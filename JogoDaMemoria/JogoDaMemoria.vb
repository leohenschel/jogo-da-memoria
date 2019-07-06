Imports System.Threading

Public Class JogoDaMemoria

    Dim listaImagens(8) As Image
    Dim acertos As Integer
    Dim posicoesEscolhidas As New List(Of String)
    Dim clicks, tagClique1, tagClique2 As Integer
    Dim imgClique1, imgClique2 As PictureBox



    Private Sub Pbox1_Click(sender As Object, e As EventArgs) Handles Pbox1.Click, Pbox2.Click, Pbox3.Click, Pbox4.Click, Pbox5.Click, Pbox6.Click, Pbox7.Click, Pbox8.Click, Pbox9.Click, Pbox10.Click, Pbox11.Click, Pbox12.Click, Pbox13.Click, Pbox14.Click, Pbox15.Click, Pbox16.Click
        VirarImagem(sender)
    End Sub

    Private Sub JogoDaMemoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NovoJogo()

    End Sub

    Private Sub NovoJogo()

        posicoesEscolhidas.Clear()
        acertos = 0



        Dim pontosX() As Integer = {150, 272, 395, 515}
        Dim pontosY() As Integer = {12, 120, 236, 348}

        'Percorre todas as Pictures BOX
        For Each pbox As PictureBox In Controls.OfType(Of PictureBox)

            Dim rdn As Random = New Random()
            Dim x, y As Integer
            Dim posicao As String

            pbox.Visible = True
            pbox.Enabled = True

            Do

                x = pontosX(rdn.Next(0, 4))
                y = pontosY(rdn.Next(0, 4))
                posicao = x & "x" & y

            Loop Until (posicoesEscolhidas.Contains(posicao) = False)

            pbox.Location = New Point(x, y)
            posicoesEscolhidas.Add(posicao)

            'Vira as imgs para o verso
            listaImagens(pbox.Tag) = pbox.Image
            pbox.Image = My.Resources.verso


        Next



    End Sub

    Sub VirarImagem(pbox As PictureBox)

        clicks = clicks + 1
        pbox.Image = listaImagens(pbox.Tag)
        pbox.Enabled = False


        If (clicks = 1) Then
            'primeira img'

            tagClique1 = pbox.Tag
            imgClique1 = pbox


        ElseIf (clicks = 2) Then
            'segunda img'

            tagClique2 = pbox.Tag
            imgClique2 = pbox


            Thread.Sleep(1000)


            Dim acertou As Boolean
            acertou = (tagClique1 = tagClique2)

            If (acertou) Then
                'acertou

                imgClique1.Visible = False
                imgClique2.Visible = False
                acertos = acertos + 1

                If (acertos = 8) Then
                    MessageBox.Show("Você Ganhouu!!!")
                    Dim pergunta As DialogResult = MessageBox.Show("Iniciar um novo jogo?", "O que fazer?", MessageBoxButtons.YesNo)
                    If (pergunta = vbYes) Then
                        NovoJogo()
                    Else
                        Application.Exit()
                    End If


                End If




            Else
                'Nao acertou

                imgClique1.Image = My.Resources.verso
                    imgClique2.Image = My.Resources.verso
                    imgClique1.Enabled = True
                    imgClique2.Enabled = True

                End If
                clicks = 0
            End If


    End Sub


End Class
