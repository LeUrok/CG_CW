#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_tabWidget_tabBarClicked(int index)
{

}


void MainWindow::on_LoadObjButton_clicked()
{
    QString text;
    if(ui->CubeRButton->isChecked())
        text = "Куб";
    else if(ui->SphereRButton->isChecked())
        text = "Сфера";
    else if(ui->ConeRButton->isChecked())
        text = "Конус";
    else if(ui->CylinderRButton->isChecked())
        text = "Цилиндр";
    else
        qDebug() << "Кнопка не выбрана";
    auto upd_text = text;

}

