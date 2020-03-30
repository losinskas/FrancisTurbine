import sqlite3

def __init__(self):
    self.conexao = sqlite3.connect('database.db')
    self.createTable()

def createTable(self):
    cursor = self.conexao.cursor()
    cursor.execute(""" create table if not exists usuarios (idusuario """)
    self