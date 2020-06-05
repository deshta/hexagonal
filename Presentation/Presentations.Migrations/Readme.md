# Gerar arquivos

## Para gerar a migração
```
add-migration NomeDaMigracao -Project Base.Infrastructure.Data.Migrations
```

## Para gerar a seed
```
add-migration seed_NomeDoSeed -Project Base.Infrastructure.Data.Migrations
```

# Para executar as migrações

## Gerar script
```
Script-migration -Project Base.Infrastructure.Data.Migrations
```
## Atualizar direto no Banco
```
Update-Database -Project Base.Infrastructure.Data.Migrations
```