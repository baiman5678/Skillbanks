
import React from 'react';
import { Layout, Card, Button, Table, Tag } from 'antd';

const { Header, Content } = Layout;

const App = () => {
  // 簡單的模擬資料
  const skillExchanges = [
    {
      key: '1',
      learnerName: '王小明',
      skillDescription: 'React 前端開發',
      wantSkill: '平面設計',
      status: '媒合中'
    },
    {
      key: '2',
      learnerName: '李美華',
      skillDescription: '英語教學',
      wantSkill: 'Python 程式設計',
      status: '媒合中'
    }
  ];

  // 簡單的表格欄位
  const columns = [
    {
      title: '發布者',
      dataIndex: 'learnerName',
      key: 'learnerName'
    },
    {
      title: '提供技能',
      dataIndex: 'skillDescription',
      key: 'skillDescription',
      render: text => <Tag color="blue">{text}</Tag>
    },
    {
      title: '想學技能',
      dataIndex: 'wantSkill',
      key: 'wantSkill',
      render: text => <Tag color="green">{text}</Tag>
    },
    {
      title: '狀態',
      dataIndex: 'status',
      key: 'status'
    },
    {
      title: '操作',
      key: 'action',
      render: () => (
        <Button type="primary" size="small">
          查看
        </Button>
      )
    }
  ];

  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Header style={{ background: '#fff', padding: '0 24px' }}>
        <h1 style={{ margin: 0, color: '#1890ff' }}>💡 技能交換平台</h1>
      </Header>
      
      <Content style={{ padding: '24px', background: '#f0f2f5' }}>
        <Card title="技能交換列表">
          <Table 
            columns={columns} 
            dataSource={skillExchanges}
            pagination={false}
          />
        </Card>
      </Content>
    </Layout>
  );
};

export default App;